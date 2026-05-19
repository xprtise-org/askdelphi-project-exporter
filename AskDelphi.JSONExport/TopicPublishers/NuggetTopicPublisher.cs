using AskDelphi.ProjectPublisher;
using AskDelphi.JSONExport.Output;
using AskDelphi.JSONExport.Utils;
using AskDelphi.EditingAPI;
using AskDelphi.EditingAPI.DTO;
using AskDelphi.EditingAPI.DTO.Project;
using AskDelphi.EditingAPI.DTO.Topic.Models;
using AskDelphi.EditingAPI.DTO.Topic.Responses;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace AskDelphi.JSONExport.TopicPublishers
{
    public class NuggetTopicPublisher(
        ILogger<NuggetTopicPublisher> logger,
        IPublicationSettings publicationSettings,
        IAskDelphiTopicClient askDelphiTopicClient,
        IAskDelphiResourceClient askDelphiResourceClient,
        IAskDelphiRelationsClient askDelphiRelationsClient,
        IPublicationTargetFilesystem fs
            ) : TopicPublisherBase(logger, publicationSettings, askDelphiTopicClient, askDelphiResourceClient, askDelphiRelationsClient, fs), ITopicPublisher
    {
        private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

        private readonly ILogger<NuggetTopicPublisher> logger = logger;
        private readonly IPublicationSettings publicationSettings = publicationSettings;
        private readonly IAskDelphiTopicClient askDelphiTopicClient = askDelphiTopicClient;
        private readonly IPublicationTargetFilesystem fs = fs;

        public bool IsPublisherFor(IAskdelphiPublisherContext context, string topicNamespace) => "http://tempuri.org/imola-nugget".Equals(topicNamespace, StringComparison.OrdinalIgnoreCase);

        public async Task<string?> PublishTopic(IAskdelphiPublisherContext context, TopicListEntryIdentifier topicListEntry, ResponseTopicVersionHistoryTableModel versionForPublicationStage)
        {
            Guid topicGuid = topicListEntry.TopicGuid;

            string filename = PathHelper.MakeValidFileName($"{topicGuid}.json");
            context.PublishedTopics[topicGuid] = filename; // Prior to publishing is set to null, fix this as early as possible in case of loops

            AnnouncePublication(logger, topicListEntry.TopicGuid, versionForPublicationStage);
            try
            {
                APIResponse<GetTopicEditorTagModelResponse> tagModelApiResponse = await askDelphiTopicClient.GetTopicEditorTagModel(context, topicGuid, versionForPublicationStage.TopicVersionId);
                ResponseTopicEditorTagModel tagModelResponse = tagModelApiResponse.Response.Data;
                List<string> tags = tagModelResponse.TopicTags.Select(x => x.HierarchyNodeTitle).ToList();

                APIResponse<GetTopicContentPartsResponse> getPartsResponse = await askDelphiTopicClient.GetContentTopicPartsV3(context, topicGuid, versionForPublicationStage.TopicVersionId);

                IEnumerable<IEnumerable<(AskDelphi.EditingAPI.DTO.Editors.EditorValue editorValue, AskDelphi.EditingAPI.DTO.Editors.TopicPartFieldEditor editor)>> partsList = PartsHelper.GetList(getPartsResponse, "content", "nugget-steps", "nugget-steps") ?? [];

                NuggetModel.NuggetStep[] list = await Task.WhenAll(partsList.Select(async (x) =>
                {
                    string? createResourceResult = await CreateResourceFor(context, topicGuid, PartsHelper.GetFile(x, "nugget-step-image"));
                    return new NuggetModel.NuggetStep
                    {
                        ImageFilename = createResourceResult,
                        Instructions = PartsHelper.GetString(x, "nugget-step-instructions"),
                        Text = PartsHelper.GetString(x, "nugget-step-text"),
                    };
                }));

                NuggetModel result = new()
                {
                    URL = $"{publicationSettings.BaseURL}/topic/{topicGuid}",
                    Guid = $"{topicGuid}",
                    Title = PartsHelper.GetString(getPartsResponse, "basic-data", "title-description", "title"),
                    ShortDescription = PartsHelper.GetString(getPartsResponse, "basic-data", "title-description", "description"),
                    KeyVisualFile = await CreateResourceFor(context, topicGuid, PartsHelper.GetResourceTopic(getPartsResponse, "media", "key-visual", "key-visual")),
                    ThumbnailFile = await CreateResourceFor(context, topicGuid, PartsHelper.GetResourceTopic(getPartsResponse, "media", "thumbnail", "thumbnail")),
                    FullDescription = PartsHelper.GetString(getPartsResponse, "content", "nugget-description", "nugget-description"),
                    Tags = tags,
                    InstructionVideoFilename = await CreateResourceFor(context, topicGuid, PartsHelper.GetResourceTopic(getPartsResponse, "content", "resources", "nugget-video")),
                    TipImageFilename = await CreateResourceFor(context, topicGuid, PartsHelper.GetResourceTopic(getPartsResponse, "content", "resources", "nugget-tip-image")),
                    TipText = PartsHelper.GetString(getPartsResponse, "content", "resources", "tip-description"),

                    Steps = list.ToList()
                };

                await AddRelatedContent(context, topicListEntry, versionForPublicationStage, result);

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
