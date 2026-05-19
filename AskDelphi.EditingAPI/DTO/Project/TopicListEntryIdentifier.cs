namespace AskDelphi.EditingAPI.DTO.Project
{
    public class TopicListEntryIdentifier
    {
        public Guid TopicGuid { get; set; }
        public bool IsEditable { get; set; }
        public bool IsLocked { get; set; }
        public DateTime LastModificationDate { get; set; }
        public string Title { get; set; }
        public Guid TopicTypeKey { get; set; }
        public string TopicTypeName { get; set; }
        public string TopicTypeNamespace { get; set; }
        public string LockedByUserName { get; set; }
        public string ThumbnailImageBase64 { get; set; }
        public string LockedByUserId { get; set; }
        /// <summary>
        /// Indicates whether topic is checked out by me
        /// </summary>
        public bool CheckedOutByMe { get; set; }
        /// <summary>
        /// Indicates whether logged in user can edit topic
        /// </summary>
        public bool CanEditTopic { get; set; }
        /// <summary>
        /// Indicates whether logged in user can break locks
        /// </summary>
        public bool CanBreakLocks { get; set; }
        /// <summary>
        /// Indicates id of the topic version
        /// </summary>
        public Guid TopicVersionKey { get; set; }

        /// <summary>
        /// Indicates that this topic has checkout versions
        /// </summary>
        public bool CurrentUserHasCheckedOutVersions { get; set; }
        /// <summary>
        /// Major version no
        /// </summary>
        public int MajorVersionNo { get; set; }
        /// <summary>
        /// Minor version no
        /// </summary>
        public int MinorVersionNo { get; set; }
    }
}
