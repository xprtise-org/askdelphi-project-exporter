using AskDelphi.ProjectPublisher;
using AskDelphi.JSONExport.Output;
using AskDelphi.JSONExport.Utils;
using AskDelphi.EditingAPI;
using AskDelphi.EditingAPI.DTO.Project;
using AskDelphi.EditingAPI.DTO.Topic.Models;
using AskDelphi.EditingAPI.DTO.Topic.Responses;
using AskDelphi.EditingAPI.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace AskDelphi.JSONExport.TopicPublishers
{
    public class PortletTopicPublisher(
        ILogger<PortletTopicPublisher> logger,
        IPublicationSettings publicationSettings,
        IAskDelphiTopicClient askDelphiTopicClient,
        IAskDelphiResourceClient askDelphiResourceClient,
        IAskDelphiRelationsClient askDelphiRelationsClient,
        IPublicationTargetFilesystem fs
            ) : TopicPublisherBase(logger, publicationSettings, askDelphiTopicClient, askDelphiResourceClient, askDelphiRelationsClient, fs), ITopicPublisher
    {
        private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };
        private readonly ILogger<PortletTopicPublisher> logger = logger;
        private readonly IPublicationSettings publicationSettings = publicationSettings;
        private readonly IAskDelphiTopicClient askDelphiTopicClient = askDelphiTopicClient;
        private readonly IPublicationTargetFilesystem fs = fs;
        public bool IsPublisherFor(IAskdelphiPublisherContext context, string topicNamespace) =>
           "http://tempuri.org/imola-portlet-about-me".Equals(topicNamespace, StringComparison.OrdinalIgnoreCase) ||
           "http://tempuri.org/imola-portlet-statistics".Equals(topicNamespace, StringComparison.OrdinalIgnoreCase) ||
           "http://tempuri.org/imola-tabbed-portlet".Equals(topicNamespace, StringComparison.OrdinalIgnoreCase) ||
           "http://tempuri.org/doppio-poll".Equals(topicNamespace, StringComparison.OrdinalIgnoreCase) ||
           "http://tempuri.org/imola-quick-question".Equals(topicNamespace, StringComparison.OrdinalIgnoreCase) ||
           "http://tempuri.org/imola-questionnaire".Equals(topicNamespace, StringComparison.OrdinalIgnoreCase) ||
           "http://tempuri.org/imola-profile-details-portlet".Equals(topicNamespace, StringComparison.OrdinalIgnoreCase) ||
           "http://tempuri.org/imola-flipcard-portlet".Equals(topicNamespace, StringComparison.OrdinalIgnoreCase);
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
                PortletModel result = new()
                {
                    URL = $"{publicationSettings.BaseURL}/topic/{topicGuid}",
                    Guid = $"{topicGuid}",
                    Title = PartsHelper.GetString(getPartsResponse, "basic-data", "title-description", "title"),
                    ShortDescription = PartsHelper.GetString(getPartsResponse, "basic-data", "title-description", "description"),
                    Tags = tags
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