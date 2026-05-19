namespace AskDelphi.EditingAPI.DTO.Topic.Responses
{
    public class GetTopicWorkflowStateResponseV2
    {
        /// <summary>
        /// Current state of the topic
        /// 0 = new,
        /// 1 = checkedin,
        /// 2 = checked out by currentuser,
        /// 3 = checked out by different user
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// True if user has access to the topic, else false
        /// </summary>
        public bool CanThisSessionAccessThisTopicForUpdate { get; set; }

        /// <summary>
        /// Indicates whether user can undo checkout of locked topics
        /// </summary>
        public bool CanBreakLocks { get; set; }
        /// <summary>
        /// Contains the error code (if any) indicating why the user is not authorised to edit the topic
        /// </summary>
        public string CanEditErrorCode { get; set; }

        /// <summary>
        /// Title of the user who has currently locked the topic if topic is not locked by current user
        /// </summary>
        public string LockedBy { get; set; }

        /// <summary>
        /// Title of the topic
        /// </summary>
        public string TopicTitle { get; set; }

        /// <summary>
        /// Inidicates that topic is deleted
        /// </summary>
        public bool IsDeleted { get; set; }


    }
}
