namespace AskDelphi.EditingAPI.DTO.Project.Models
{
    /// <summary>
    /// Event for logging topic workflow state changes
    /// </summary>
    public class ResponseTopicWorkflowStateProjectEvent : ResponseProjectEventLogTypeBase
    {
        /// <summary>
        /// Topic id
        /// </summary>
        public Guid TopicGuid { get; set; }

        /// <summary>
        /// Topic title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// New state of the topic
        /// </summary>
        public ProjectEventLogTopicWorkflowState State { get; set; }

        /// <summary>
        /// Topic version at which the state was set
        /// </summary>
        public string TopicVersion { get; set; }
    }

    public enum ProjectEventLogTopicWorkflowState
    {
        /// <summary></summary>
        New,
        /// <summary></summary>
        CheckedIn,
        /// <summary></summary>
        CheckedOut,
        /// <summary></summary>
        Deleted
    }
}
