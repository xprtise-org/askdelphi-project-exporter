using AskDelphi.JSONExport;
using AskDelphi.EditingAPI.DTO.Project;
using AskDelphi.EditingAPI.DTO.Topic.Models;

namespace AskDelphi.ProjectPublisher
{
    public interface ITopicPublisher
    {
        bool IsPublisherFor(IAskdelphiPublisherContext context, string topicNamespace);
        Task<string?> PublishTopic(IAskdelphiPublisherContext context, TopicListEntryIdentifier topicListEntry, ResponseTopicVersionHistoryTableModel versionForPublicationStage);
    }
}