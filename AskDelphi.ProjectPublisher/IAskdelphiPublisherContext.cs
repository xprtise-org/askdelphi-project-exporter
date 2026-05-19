using AskDelphi.ProjectPublisher;
using AskDelphi.EditingAPI;
using AskDelphi.EditingAPI.DTO;

namespace AskDelphi.JSONExport
{
    public interface IAskdelphiPublisherContext : IAskDelphiAPIContext
    {
        Dictionary<Guid, string?> PublishedTopics { get; set; }
        GetContentDesignResponse? ContentDesign { get; set; }
        ITopicPublisherFactory? TopicPublisherFactory { get; set; }
        List<PublicationSettings.RuleConfiguration>? ContentSet { get; set; }
    }
}