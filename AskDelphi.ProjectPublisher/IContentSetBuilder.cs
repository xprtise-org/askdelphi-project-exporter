using AskDelphi.JSONExport;
using AskDelphi.EditingAPI.DTO.Project;
using AskDelphi.EditingAPI.DTO.Topic.Models;

namespace AskDelphi.ProjectPublisher
{
    public interface IContentSetBuilder
    {
        Task<List<(TopicListEntryIdentifier topicListEntry, ResponseTopicVersionHistoryTableModel version)>> BuildContentSet(IAskdelphiPublisherContext context);
    }
}