namespace AskDelphi.EditingAPI.DTO.Topic.Requests
{
    /// <summary>
    /// Contains information about the request action for topic
    /// </summary>
    public class PostTopicWorkflowStateRequest
    {
        /// <summary>
        /// Action to be performed on topic
        /// </summary>
        public TopicWorkflowStateActionEnum Action { get; set; }
    }
}
