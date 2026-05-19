namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Models
{
    /// <summary>
    /// Contains display information of all the topics that match content set definition for a workflow transition request
    /// </summary>
    /// <remarks>
    /// Contains information about topics and their versions, that will be transitioned once the workflow transition request is approved
    /// </remarks>
    public class ResponseWorkflowTransitionRequestMatchingTopicDisplayModel
    {
        /// <summary>
        /// Topic unique identifier
        /// </summary>
        public Guid TopicId { get; set; }
        /// <summary>
        /// Title of the topic
        /// </summary>
        public string TopicTitle { get; set; }
        /// <summary>
        /// Display name of the topic type
        /// </summary>
        public string TopicTypeDisplayName { get; set; }
        /// <summary>
        /// Indicates the source stage that the topic will be transitioned from
        /// </summary>
        public string FromStageTitle { get; set; }
        /// <summary>
        /// Indicates the target stage that the topic will be transitioned to
        /// </summary>
        public string ToStageTitle { get; set; }
        /// <summary>
        /// Indicates the source topic version (at source stage)
        /// </summary>
        public Guid FromTopicVersionId { get; set; }
        /// <summary>
        /// Indicates target topic version (at target stage), which potentially does not exist yet
        /// </summary>
        public Guid? ToTopicVersionId { get; set; }
    }
}
