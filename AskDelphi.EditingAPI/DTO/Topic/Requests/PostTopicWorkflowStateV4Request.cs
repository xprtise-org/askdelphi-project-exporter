using AskDelphi.EditingAPI.DTO.Topic.Models;

namespace AskDelphi.EditingAPI.DTO.Topic.Requests
{
    /// <summary>
    /// Contains information about the request action for topic
    /// </summary>
    public class PostTopicWorkflowStateV4Request
    {
        /// <summary>
        /// Action to be performed on topic
        /// </summary>
        public TopicWorkflowStateActionEnum Action { get; set; }

        /// <summary>
        /// Indicates if topic is externally sourced
        /// </summary>
        public bool IsExternal { get; set; }

        /// <summary>
        /// Indicates the external uri for externally sourced topic (remote-uri://adapterId/topicId)
        /// </summary>
        public string ExternalUri { get; set; }

        /// <summary>
        /// External source topic title
        /// </summary>
        public string ExternalTopicTitle { get; set; }
        /// <summary>
        /// External source topic namespace
        /// </summary>
        public string ExternalTopicNamespace { get; set; }

        /// <summary>
        /// Additional workflow related actions
        /// </summary>
        public RequestTopicWorkflowActionModel WorkflowActions { get; set; }
    }
}
