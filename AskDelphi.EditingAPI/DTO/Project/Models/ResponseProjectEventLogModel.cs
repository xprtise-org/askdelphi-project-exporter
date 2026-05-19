namespace AskDelphi.EditingAPI.DTO.Project.Models
{
    /// <summary>
    /// Project event model that represents a single project event
    /// </summary>
    public class ResponseProjectEventLogModel
    {
        /// <summary>
        /// Unique id of the event
        /// </summary>

        public Guid Key { get; set; }
        /// <summary>
        /// Project id
        /// </summary>

        public Guid ProjectGuid { get; set; }
        /// <summary>
        /// Date, the event occured
        /// </summary>

        public DateTimeOffset CreationDate { get; set; }
        /// <summary>
        /// Event type
        /// </summary>

        public ProjectEventLogType EventType { get; set; }
        /// <summary>
        /// Created by user id
        /// </summary>

        public Guid CreateByUserKey { get; set; }

        /// <summary>
        /// Contains information about full publication event
        /// </summary>

        public ResponseFullPublicationStartedProjectEvent FullPublicationStartedData { get; set; }
        /// <summary>
        /// Contains information about publication modified event
        /// </summary>

        public ResponsePublicationModificationProjectEvent PublicationModifiedData { get; set; }
        /// <summary>
        /// Contains information about topic checked-in event
        /// </summary>

        public ResponseTopicCheckedInProjectEvent TopicCheckedInData { get; set; }
        /// <summary>
        /// Contains information about publication flag changed event
        /// </summary>

        public ResponseTopicPublishFlagChangedProjectEvent PublishFlagChangedData { get; set; }
        /// <summary>
        /// Contains information about topic workflow state event
        /// </summary>

        public ResponseTopicWorkflowStateProjectEvent TopicWorkflowStateData { get; set; }

    }

    public enum ProjectEventLogType
    {
        /// <summary></summary>
        TopicCheckedIn,
        /// <summary></summary>
        PublicationModified,
        /// <summary></summary>
        TopicMarkedDoNotPublish,
        /// <summary></summary>
        TopicVersionState,
        /// <summary></summary>
        FullPublicationStarted
    }
}
