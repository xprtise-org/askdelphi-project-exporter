namespace AskDelphi.EditingAPI.DTO.Topic.Models
{
    /// <summary>
    /// Contains topic information at specifc version
    /// </summary>
    public class ResponseTopicVersionDetails
    {
        /// <summary>
        /// Topic id
        /// </summary>
        public Guid TopicId { get; set; }
        /// <summary>
        /// Topic version id
        /// </summary>
        public Guid TopicVersionId { get; set; }
        /// <summary>
        /// Topic title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Topic's description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Indicates whether topic is deleted
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Indicates whether topic is marked as do-not-publish
        /// </summary>
        public bool MarkedDoNotPublish { get; set; }
        /// <summary>
        /// The date when the version was created
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Major and minor versions of the topic
        /// </summary>
        public string TopicVersion { get; set; }
        /// <summary>
        /// Created by user id
        /// </summary>
        public Guid CreatedByUserId { get; set; }
        /// <summary>
        /// Name of the user that created the topic version
        /// </summary>
        public string CreatedByName { get; set; }
        /// <summary>
        /// The state of this topic at this version
        /// </summary>
        public TopicLockedStateForUser State { get; set; }
        /// <summary>
        /// Topic html, for readonly/comparison purposes
        /// </summary>
        public string TopicHtml { get; set; }
        /// <summary>
        /// Topic is enabled or not
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// Guid for the thumbnail topic
        /// </summary>
        public Guid? ThumbnailTopicGuid { get; set; }
        /// <summary>
        /// Thumbnail topic title
        /// </summary>
        public string ThumbnailTopicTitle { get; set; }
        /// <summary>
        /// Guid for the key visual topic
        /// </summary>
        public Guid? KeyVisualTopicGuid { get; set; }
        /// <summary>
        /// Key visual topic title
        /// </summary>
        public string KeyVisualTopicTitle { get; set; }
        /// <summary>
        /// Keywords used for the topic
        /// </summary>
        public string Keywords { get; set; }
        /// <summary>
        /// Contains information about topic relations/references
        /// </summary>
        public IEnumerable<ResponseTopicVersionDetailsGroupReference> ReferenceGroups { get; set; }
    }
}
