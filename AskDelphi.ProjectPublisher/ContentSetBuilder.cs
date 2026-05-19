using AskDelphi.JSONExport;
using AskDelphi.EditingAPI;
using AskDelphi.EditingAPI.DTO;
using AskDelphi.EditingAPI.DTO.Project;
using AskDelphi.EditingAPI.DTO.Topic.Models;
using AskDelphi.EditingAPI.DTO.Topic.Responses;
using Microsoft.Extensions.Logging;

namespace AskDelphi.ProjectPublisher
{
    public class ContentSetBuilder(
        ILogger<ContentSetBuilder> logger,
        IPublicationSettings publicationSettings,
        IAskDelphiProjectClient askDelphiProjectClient,
        IAskDelphiTopicClient askDelphiTopicClient
            ) : IContentSetBuilder
    {
        private readonly ILogger<ContentSetBuilder> logger = logger;
        private readonly IPublicationSettings publicationSettings = publicationSettings;
        private readonly IAskDelphiProjectClient askDelphiProjectClient = askDelphiProjectClient;
        private readonly IAskDelphiTopicClient askDelphiTopicClient = askDelphiTopicClient;

        public async Task<List<(TopicListEntryIdentifier topicListEntry, ResponseTopicVersionHistoryTableModel version)>> BuildContentSet(IAskdelphiPublisherContext context)
        {
            List<(TopicListEntryIdentifier topicListEntry, ResponseTopicVersionHistoryTableModel version)> calculatedContentSet = [];
            foreach (var rule in publicationSettings?.ContentSet ?? [])
            {
                switch (rule.Type)
                {
                    case PublicationSettings.RuleConfiguration.RuleType.IncludeAll:
                        await IncludeAll(context, calculatedContentSet);
                        break;
                    case PublicationSettings.RuleConfiguration.RuleType.IncludeTopicsWithTag:
                        await IncludeTaggedTopics(context, calculatedContentSet, rule.IncludeTopicsWithTag);
                        break;
                    case PublicationSettings.RuleConfiguration.RuleType.IncludeRelatedTopics:
                        await IncludeRelatedTopics(context, calculatedContentSet, rule.IncludeRelatedTopics);
                        break;
                    case PublicationSettings.RuleConfiguration.RuleType.IncludeTopicsOfType:
                        await IncludeTopicsOfType(context, calculatedContentSet, rule.IncludeTopicsOfType);
                        break;
                    case PublicationSettings.RuleConfiguration.RuleType.IncludeTopicsOfNamespace:
                        await IncludeTopicsOfNamespace(context, calculatedContentSet, rule.IncludeTopicsOfNamespace);
                        break;
                    case PublicationSettings.RuleConfiguration.RuleType.IncludeSpecificTopic:
                        await IncludeSpecificTopic(context, calculatedContentSet, rule.IncludeSpecificTopic);
                        break;
                    default:
                        logger.LogWarning("Ignoring unsupported rule type {Type} in content set.", rule.Type);
                        break;
                }
            }
            return calculatedContentSet;
        }

        private async Task IncludeAll(IAskdelphiPublisherContext context, List<(TopicListEntryIdentifier topicListEntry, ResponseTopicVersionHistoryTableModel version)> calculatedContentSet)
        {
            var criteria = new PostTopicListRequest
            {
                Page = 1,
                PageSize = Int32.MaxValue
            };
            await AddMatchingContentToContentSet(context, calculatedContentSet, criteria, (e) => true);
        }

        private async Task IncludeTaggedTopics(IAskdelphiPublisherContext context, List<(TopicListEntryIdentifier topicListEntry, ResponseTopicVersionHistoryTableModel version)> calculatedContentSet, PublicationSettings.RuleConfiguration.IncludeTopicsWithTagData? includeTopicsWithTag)
        {
            if (null == includeTopicsWithTag) return;

            var criteria = new PostTopicListRequest
            {
                Page = 1,
                PageSize = Int32.MaxValue,
                TaggedToNode = new AskDelphi.EditingAPI.DTO.Shared.KeyValuePair { Key = includeTopicsWithTag.HierarchyName, Value = includeTopicsWithTag.Tag }
            };
            await AddMatchingContentToContentSet(context, calculatedContentSet, criteria, (e) => true);
        }

        private async Task IncludeSpecificTopic(IAskdelphiPublisherContext context, List<(TopicListEntryIdentifier topicListEntry, ResponseTopicVersionHistoryTableModel version)> calculatedContentSet, PublicationSettings.RuleConfiguration.IncludeSpecificTopicData? includeSpecificTopic)
        {
            if (null == includeSpecificTopic) return;

            var criteria = new PostTopicListRequest
            {
                Page = 1,
                PageSize = Int32.MaxValue,
                Query = $"{includeSpecificTopic.TopicGuid}"
            };
            await AddMatchingContentToContentSet(context, calculatedContentSet, criteria, (e) => e.TopicGuid == includeSpecificTopic.TopicGuid);
        }

        private async Task IncludeTopicsOfType(IAskdelphiPublisherContext context, List<(TopicListEntryIdentifier topicListEntry, ResponseTopicVersionHistoryTableModel version)> calculatedContentSet, PublicationSettings.RuleConfiguration.IncludeTopicsOfTypeData? includeTopicsOfType)
        {
            if (null == includeTopicsOfType) return;

            var criteria = new PostTopicListRequest
            {
                Page = 1,
                PageSize = Int32.MaxValue,
                TopicTypes = [includeTopicsOfType.TopicTypeGuid]
            };
            await AddMatchingContentToContentSet(context, calculatedContentSet, criteria, (e) => true);
        }

        private async Task IncludeRelatedTopics(IAskdelphiPublisherContext context, List<(TopicListEntryIdentifier topicListEntry, ResponseTopicVersionHistoryTableModel version)> calculatedContentSet, PublicationSettings.RuleConfiguration.IncludeRelatedTopicsData? includeRelatedTopics)
        {
            throw await Task.FromResult(new NotImplementedException());
        }

        private async Task IncludeTopicsOfNamespace(IAskdelphiPublisherContext context, List<(TopicListEntryIdentifier topicListEntry, ResponseTopicVersionHistoryTableModel version)> calculatedContentSet, PublicationSettings.RuleConfiguration.IncludeTopicsOfNamespaceData? includeTopicsOfNamespace)
        {
            if (null == includeTopicsOfNamespace) return;

            var criteria = new PostTopicListRequest
            {
                Page = 1,
                PageSize = Int32.MaxValue,
                Namespaces = [includeTopicsOfNamespace.Namespace]
            };
            await AddMatchingContentToContentSet(context, calculatedContentSet, criteria, (e) => true);
        }

        private async Task AddMatchingContentToContentSet(IAskdelphiPublisherContext context, List<(TopicListEntryIdentifier topicListEntry, ResponseTopicVersionHistoryTableModel version)> calculatedContentSet, PostTopicListRequest criteria, Func<TopicListEntryIdentifier, bool> isMatch)
        {
            APIResponse<PostTopicListResponse> postTopicListResponse = await askDelphiProjectClient.PostTopicListRequest(context, criteria);
            foreach (TopicListEntryIdentifier? topicListEntry in postTopicListResponse?.Response?.TopicList?.Result ?? [])
            {
                if (null == topicListEntry)
                {
                    continue;
                }

                if (calculatedContentSet.Any(x => x.topicListEntry.TopicGuid == topicListEntry.TopicGuid))
                {
                    continue;
                }

                if (!isMatch(topicListEntry))
                {
                    continue;
                }

                try
                {
                    APIResponse<PostSearchTopicVersionHistoryTableResponse> postSearchTopicVersionHistoryTableResponse = await askDelphiTopicClient.PostSearchTopicVersionHistoryTable(context, topicListEntry.TopicGuid, new()
                    {
                        ExcludeVersionsWithoutStages = true,
                    });

                    if (null != postSearchTopicVersionHistoryTableResponse)
                    {
                        ResponseTopicVersionHistoryTableModel? versionForPublicationStage = postSearchTopicVersionHistoryTableResponse.Response.Data.Where(x => x.StageTitles.Any(st => string.Equals(publicationSettings.WorkflowStageTitle, st, StringComparison.OrdinalIgnoreCase))).FirstOrDefault();
                        if (null != versionForPublicationStage)
                        {
                            calculatedContentSet.Add((topicListEntry, versionForPublicationStage));
                        }
                        else
                        {
                            logger.LogWarning("Topic {TopicGuid} has no versions.", topicListEntry.TopicGuid);
                        }
                    }
                    else
                    {
                        logger.LogWarning("Topic {TopicGuid} has no versions.", topicListEntry.TopicGuid);
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error fetching available versions for topic {TopicGuid}, skipping topic", topicListEntry.TopicGuid);
                }
            }
        }
    }
}
