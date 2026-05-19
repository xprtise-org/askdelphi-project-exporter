using AskDelphi.ProjectPublisher;
using AskDelphi.JSONExport.Output;
using AskDelphi.JSONExport.Utils;
using AskDelphi.EditingAPI;
using AskDelphi.EditingAPI.DTO;
using AskDelphi.EditingAPI.DTO.Editors;
using AskDelphi.EditingAPI.DTO.Project;
using AskDelphi.EditingAPI.DTO.Topic.Models;
using AskDelphi.EditingAPI.DTO.Topic.Responses;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text.Json;

namespace AskDelphi.JSONExport.TopicPublishers
{
    public class CollectionTopicPublisher(
        ILogger<CollectionTopicPublisher> logger,
        IPublicationSettings publicationSettings,
        IAskDelphiTopicClient askDelphiTopicClient,
        IAskDelphiResourceClient askDelphiResourceClient,
        IAskDelphiRelationsClient askDelphiRelationsClient,
        IPublicationTargetFilesystem fs
            ) : TopicPublisherBase(logger, publicationSettings, askDelphiTopicClient, askDelphiResourceClient, askDelphiRelationsClient, fs), ITopicPublisher
    {
        private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };
        private readonly ILogger<CollectionTopicPublisher> logger = logger;
        private readonly IPublicationSettings publicationSettings = publicationSettings;
        private readonly IAskDelphiTopicClient askDelphiTopicClient = askDelphiTopicClient;
        private readonly IPublicationTargetFilesystem fs = fs;

        public bool IsPublisherFor(IAskdelphiPublisherContext context, string topicNamespace) => "http://tempuri.org/imola-collection".Equals(topicNamespace, StringComparison.OrdinalIgnoreCase);

        public async Task<string?> PublishTopic(IAskdelphiPublisherContext context, TopicListEntryIdentifier topicListEntry, ResponseTopicVersionHistoryTableModel versionForPublicationStage)
        {
            Guid topicGuid = topicListEntry.TopicGuid;
            string filename = PathHelper.MakeValidFileName($"{topicGuid}.json");
            context.PublishedTopics[topicGuid] = filename; // Prior to publishing is set to null, fix this as early as possible in case of loops

            AnnouncePublication(logger, topicListEntry.TopicGuid, versionForPublicationStage);
            try
            {
                APIResponse<GetTopicEditorTagModelResponse> tagModelApiResponse = await askDelphiTopicClient.GetTopicEditorTagModel(context, topicGuid, versionForPublicationStage.TopicVersionId);
                APIResponse<GetTopicContentPartsResponse> getPartsResponse = await askDelphiTopicClient.GetContentTopicPartsV3(context, topicGuid, versionForPublicationStage.TopicVersionId);

                ResponseTopicEditorTagModel tagModelResponse = tagModelApiResponse.Response.Data;
                List<string> tags = tagModelResponse.TopicTags.Select(x => x.HierarchyNodeTitle).ToList();

                CollectionModel result = new();
                result.URL = $"{publicationSettings.BaseURL}/topic/{topicGuid}";
                result.Guid = $"{topicGuid}";
                result.Title = PartsHelper.GetString(getPartsResponse, "basic-data", "title-description", "title");
                result.ShortDescription = PartsHelper.GetString(getPartsResponse, "basic-data", "title-description", "description");
                result.KeyVisualFile = await CreateResourceFor(context, topicGuid, PartsHelper.GetResourceTopic(getPartsResponse, "media", "key-visual", "key-visual"));
                result.ThumbnailFile = await CreateResourceFor(context, topicGuid, PartsHelper.GetResourceTopic(getPartsResponse, "media", "thumbnail", "thumbnail"));
                result.Tags = tags;

                // for collections we first add the related content ensuring that the files for all targets in the items of the collection already exist
                await AddRelatedContent(context, topicListEntry, versionForPublicationStage, result);

                var parts = PartsHelper.GetList(getPartsResponse, "content", "items-part", "items-part-editor") ?? [];
                CollectionModel.CollectionItemModel[] items = await Task.WhenAll(parts.Select(async (x) =>
                {
                    SingleTopicChooserValueData? targetTopic = PartsHelper.GetSingleTopicChooserValue(x, "items-part-item-target-topic");
                    Guid targetTopicGuid = null == targetTopic ? Guid.Empty : new Guid(targetTopic.TopicId);

                    // check if the target topic is already published, we moved AddRelatedContent to the beginning to
                    // ensure that all targets are published before we enter this loop                    
                    context.PublishedTopics.TryGetValue(targetTopicGuid, out string? relatedContentFile);

                    string? mediaFile = await CreateResourceFor(context, topicGuid, PartsHelper.GetFile(x, "items-part-item-media-topic"));

                    return new CollectionModel.CollectionItemModel
                    {
                        ButtonLabel = PartsHelper.GetString(x, "items-part-item-button-label"),
                        MediaFile = mediaFile,
                        Target = String.IsNullOrEmpty(relatedContentFile) ? null : new()
                        {
                            Filename = relatedContentFile,
                            TopicGuid = targetTopicGuid
                        },
                        Body = PartsHelper.GetString(x, "items-part-item-description"),
                        Title = PartsHelper.GetString(x, "items-part-item-title"),
                    };
                }));
                result.Items = items.ToList();

                result.Hash = null;
                string hash = HashHelper.Hash(JsonSerializer.Serialize(result, jsonSerializerOptions));
                result.Hash = hash;

                await fs.WriteText(filename, JsonSerializer.Serialize(result, jsonSerializerOptions), "application/json");

                return filename;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to publish topic with guid {TopicGuid} ({TopicTitle}).", topicGuid, versionForPublicationStage.TopicTitle);
                return null;
            }
        }
    }
}