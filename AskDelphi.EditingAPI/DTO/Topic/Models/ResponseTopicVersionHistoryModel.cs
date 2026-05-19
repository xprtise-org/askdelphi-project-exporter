namespace AskDelphi.EditingAPI.DTO.Topic.Models
{
    /// <summary>
    /// Response object containing information about topic version history entry
    /// </summary>
    public class ResponseTopicVersionHistoryModel
    {
        /// <summary>
        /// Topic id
        /// </summary>
        public Guid TopicGuid { get; set; }
        /// <summary>
        /// Topic version id
        /// </summary>
        public Guid TopicVersionGuid { get; set; }
        /// <summary>
        /// Topic version number in format Marjor.Minor
        /// </summary>
        public string VersionNumber { get; set; }
        /// <summary>
        /// Date topic version was created
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Date topic version was modified
        /// </summary>
        public DateTime ModificationDate { get; set; }
        /// <summary>
        /// Title of the topic at this topic version
        /// </summary>
        public string TopicTitle { get; set; }
        /// <summary>
        /// Indicates whether version is checked in
        /// </summary>
        public bool IsCheckedInVersion { get; set; }
        /// <summary>
        /// Indicates whether version is checked out
        /// </summary>
        public bool IsCheckedOutVersion { get; set; }
        /// <summary>
        /// Indicates the title/name of the user who created the version
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// The id of the user who created the topic version
        /// </summary>
        public Guid CreatedById { get; set; }
        /// <summary>
        /// The state of the topic at current version
        /// </summary>
        public TopicLockedStateForUser TopicState { get; set; }
        /// <summary>
        /// The label of the topic version, used in version workflow
        /// </summary>
        public string TopicVersionLabel { get; set; }
        /// <summary>
        /// The id of the parent topic version
        /// </summary>
        public Guid? ParentVersionId { get; set; }

        /// <summary>
        /// Inidicates if topic is deleted
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
