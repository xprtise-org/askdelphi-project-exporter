using AskDelphi.ProjectPublisher;
using AskDelphi.EditingAPI;
using AskDelphi.EditingAPI.DTO;

namespace AskDelphi.JSONExport
{
    public class AskdelphiPublisherContext : AskDelphiAPIContext, IAskdelphiPublisherContext
    {
        /// <summary>
        /// Publisher components must add any content they publish to this list.
        /// </summary>
        public Dictionary<Guid, string?> PublishedTopics { get; set; } = [];

        /// <summary>
        /// The content design for the current project.
        /// </summary>
        public GetContentDesignResponse? ContentDesign { get; set; }

        /// <summary>
        /// Topic publisher factory.
        /// </summary>
        public ITopicPublisherFactory? TopicPublisherFactory { get; set; }

        /// <summary>
        /// The content set that's currently in use.
        /// </summary>
        public List<PublicationSettings.RuleConfiguration>? ContentSet { get; set; }
    }
}
