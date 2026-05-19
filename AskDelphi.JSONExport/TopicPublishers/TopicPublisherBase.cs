using AskDelphi.ProjectPublisher;
using AskDelphi.JSONExport.Output;
using AskDelphi.JSONExport.Utils;
using AskDelphi.EditingAPI;
using AskDelphi.EditingAPI.DTO;
using AskDelphi.EditingAPI.DTO.Editors;
using AskDelphi.EditingAPI.DTO.Project;
using AskDelphi.EditingAPI.DTO.Shared;
using AskDelphi.EditingAPI.DTO.Topic.Models;
using AskDelphi.EditingAPI.DTO.Topic.Responses;
using Microsoft.Extensions.Logging;
using static AskDelphi.EditingAPI.DTO.GetContentDesignResponse;

namespace AskDelphi.JSONExport
{
    public abstract class TopicPublisherBase(
        ILogger logger,
        IPublicationSettings publicationSettings,
        IAskDelphiTopicClient askDelphiTopicClient,
        IAskDelphiResourceClient askDelphiResourceClient,
        IAskDelphiRelationsClient askDelphiRelationsClient,
        IPublicationTargetFilesystem fs)
    {
        private readonly ILogger logger = logger;
        private readonly IPublicationSettings publicationSettings = publicationSettings;
        private readonly IAskDelphiTopicClient askDelphiTopicClient = askDelphiTopicClient;
        private readonly IAskDelphiResourceClient askDelphiResourceClient = askDelphiResourceClient;
        private readonly IAskDelphiRelationsClient askDelphiRelationsClient = askDelphiRelationsClient;
        private readonly IPublicationTargetFilesystem fs = fs;

        protected async Task<string?> CreateResourceFor(IAskdelphiPublisherContext context, Guid parentTopicGuid, SingleTopicChooserValueData? singleTopicChooserValueData)
        {
            try
            {
                if (null == singleTopicChooserValueData || !Guid.TryParse(singleTopicChooserValueData.TopicId, out Guid topicGuid) || topicGuid == Guid.Empty) return null;

                APIResponse<PostSearchTopicVersionHistoryTableResponse> postSearchTopicVersionHistoryTableResponse = await askDelphiTopicClient.PostSearchTopicVersionHistoryTable(context, topicGuid, new()
                {
                    ExcludeVersionsWithoutStages = true,
                });
                ResponseTopicVersionHistoryTableModel? versionForPublicationStage = postSearchTopicVersionHistoryTableResponse.Response.Data.Where(x => x.StageTitles.Any(st => string.Equals(publicationSettings.WorkflowStageTitle, st, StringComparison.OrdinalIgnoreCase))).FirstOrDefault();
                if (null == versionForPublicationStage) return null;

                APIResponse<GetTopicContentPartsResponse> getPartsResponse = await askDelphiTopicClient.GetContentTopicPartsV3(context, topicGuid, versionForPublicationStage.TopicVersionId);
                if (null == getPartsResponse) return null;

                FileValueData? fileData = PartsHelper.GetFileValueData(getPartsResponse, "content", "file-meta-data", "file-upload");
                if (null == fileData) return null;

                Guid resourceGuid = fileData.ResourceId;

                byte[] resourceStream = await askDelphiResourceClient.DownloadResource(context, resourceGuid);
                string resourcePath = Path.Combine("resources", $"{parentTopicGuid}");
                string filename = Path.Combine(resourcePath, PathHelper.MakeValidFileName(string.IsNullOrWhiteSpace(fileData.FileName) ? $"{singleTopicChooserValueData.TopicTitle}.{fileData.MimeType.Split('/')[^1]}" : $"{fileData.FileName}"));
                await fs.WriteBytes(filename, resourceStream, fileData.MimeType);

                return $"{filename}".Replace('\\', '/');
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to create resource, returning null");
                return null;
            }
        }

        protected async Task<string?> CreateResourceFor(IAskdelphiPublisherContext context, Guid parentTopicGuid, FileValueData? fileValueData, string contentType, string basename)
        {
            try
            {
                if (null == fileValueData || Guid.Empty == fileValueData.ResourceId) return null;

                Guid resourceGuid = fileValueData.ResourceId;

                byte[] resourceStream = await askDelphiResourceClient.DownloadResource(context, resourceGuid);
                string resourcePath = Path.Combine("resources", $"{parentTopicGuid}");
                string generatedName = fileValueData.FileName;
                if (string.IsNullOrEmpty(generatedName))
                {
                    string extension = MimeTypeMap.GetExtension(fileValueData.MimeType);
                    if (string.IsNullOrEmpty(extension)) extension = MimeTypeMap.GetExtension(contentType);
                    if (string.IsNullOrEmpty(extension)) extension = ".blob";
                    generatedName = $"{basename}{extension}";
                }
                string filename = Path.Combine(resourcePath, PathHelper.MakeValidFileName(generatedName));
                await fs.WriteBytes(filename, resourceStream, fileValueData.MimeType);

                return $"{filename}".Replace('\\', '/');
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to create resource, returning null");
                return null;
            }
        }

        protected async Task AddRelatedContent(IAskdelphiPublisherContext context, TopicListEntryIdentifier topicListEntry, ResponseTopicVersionHistoryTableModel versionForPublicationStage, IModelWithRelatedContent result)
        {
            APIResponse<GetTopicRelationsCategorizedResponse> response = await askDelphiRelationsClient.GetRelationsCategorized(context, topicListEntry.TopicGuid, versionForPublicationStage.TopicVersionId, null);
            if (null == response?.Response?.PyramidLevels && null == response?.Response?.NonPyramidRelations)
            {
                return;
            }
            // include non-pyramid releations 
            foreach (TopicRelationDefinition topicRelation in response?.Response?.NonPyramidRelations?.Where(x => x != null) ?? [])
            {
                await AddRelatedContentIfTargetIsPublished(context, result, topicRelation, isChild: false);
            }
            // include pyramid relations
            foreach (GetTopicRelationsCategorizedResponse.TopicPyramidLevel pyramidLevel in response?.Response?.PyramidLevels?.Where(x => x != null) ?? [])
            {
                foreach (AskDelphi.EditingAPI.DTO.Shared.TopicRelationDefinition topicRelation in pyramidLevel.Relations?.Where(x => x != null) ?? [])
                {
                    bool isChild = context.ContentDesign?.TopicTypes.FirstOrDefault(x => x.Key == topicListEntry.TopicTypeKey)?.NextPyramidLevelTitle == pyramidLevel.Title;
                    await AddRelatedContentIfTargetIsPublished(context, result, topicRelation, isChild);
                }
            }
        }

        private async Task AddRelatedContentIfTargetIsPublished(IAskdelphiPublisherContext context, IModelWithRelatedContent result, TopicRelationDefinition topicRelation, bool isChild)
        {
            string? filename = await PublishRelatedContent(context, topicRelation);
            if (!string.IsNullOrWhiteSpace(filename))
            {
                result.RelatedContent.Add(new()
                {
                    PyramidLevel = topicRelation.PyramidLevelName,
                    TargetFile = filename,
                    TargetTitle = topicRelation.TargetTopicName,
                    IsChild = isChild
                });
            }
        }

        private async Task<string?> PublishRelatedContent(IAskdelphiPublisherContext context, AskDelphi.EditingAPI.DTO.Shared.TopicRelationDefinition topicRelation)
        {
            try
            {
                APIResponse<PostSearchTopicVersionHistoryTableResponse> postSearchTopicVersionHistoryTableResponse = await askDelphiTopicClient.PostSearchTopicVersionHistoryTable(context, topicRelation.TargetTopicId, new()
                {
                    ExcludeVersionsWithoutStages = true,
                });

                if (null != postSearchTopicVersionHistoryTableResponse)
                {
                    ResponseTopicVersionHistoryTableModel? targetVersionInStage = postSearchTopicVersionHistoryTableResponse.Response.Data.Where(x => x.StageTitles.Any(st => string.Equals(publicationSettings.WorkflowStageTitle, st, StringComparison.OrdinalIgnoreCase))).FirstOrDefault();
                    if (null != targetVersionInStage)
                    {
                        return await PublishRelationTarget(context, topicRelation, targetVersionInStage);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed fo publish relation.");
                return null;
            }
        }

        private async Task<string?> PublishRelationTarget(IAskdelphiPublisherContext context, AskDelphi.EditingAPI.DTO.Shared.TopicRelationDefinition topicRelation, ResponseTopicVersionHistoryTableModel targetVersionInStage)
        {
            if (!context.PublishedTopics.TryGetValue(topicRelation.TargetTopicId, out string? relatedContentFile))
            {
                ITopicPublisher? topicPublisher = context.TopicPublisherFactory?.GetTopicPublisher(context, topicRelation.TargetTopicNamespace);
                if (null == topicPublisher)
                {
                    logger.LogWarning("There is no topic publisher for the {Namespace} namespace. Skipping topic {TopicGuid}.", topicRelation.TargetTopicNamespace, topicRelation.TargetTopicId);
                }
                else
                {
                    if (!Guid.TryParse(topicRelation.RelationTypeKey, out Guid rk)) rk = default;
                    Guid ttID = context.ContentDesign?.TopicTypes.SelectMany(x => x.Relations.Select(r => new { r.Key, r, x })).FirstOrDefault(y => y.Key == rk)?.x.Key ?? default;
                    TopicListEntryIdentifier targetEntry = new()
                    {
                        TopicGuid = topicRelation.TargetTopicId,
                        TopicTypeKey = ttID,
                        MajorVersionNo = targetVersionInStage.MajorVersionNo,
                        MinorVersionNo = targetVersionInStage.MinorVersionNo,
                        LastModificationDate = targetVersionInStage.DateModified,
                        Title = targetVersionInStage.TopicTitle,
                        TopicTypeNamespace = topicRelation.TargetTopicNamespace,
                        TopicVersionKey = targetVersionInStage.TopicVersionId
                    };
                    context.PublishedTopics[topicRelation.TargetTopicId] = null; // Topics referring to themselves would otherwise cause a circular reference
                    relatedContentFile = await topicPublisher.PublishTopic(context, targetEntry, targetVersionInStage);
                    context.PublishedTopics[topicRelation.TargetTopicId] = relatedContentFile;
                }
            }
            return relatedContentFile;
        }

        protected static void AnnouncePublication(ILogger logger, Guid topicGuid, ResponseTopicVersionHistoryTableModel versionForPublicationStage)
        {
            logger.LogInformation("Publishing topic {TopicTitle} with ID {TopicGuid} from version {Major}.{Minor} which is in stages {Stages}", versionForPublicationStage.TopicTitle, topicGuid, versionForPublicationStage.MajorVersionNo, versionForPublicationStage.MinorVersionNo, versionForPublicationStage.StageTitleStr);
        }
    }
}