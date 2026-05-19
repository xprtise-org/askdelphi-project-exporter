namespace AskDelphi.EditingAPI.DTO.Topic.Models
{
    /// <summary>
    /// Contains information about topic version reference
    /// </summary>
    public class ResponseTopicVersionDetailsReference
    {
        /// <summary>
        /// Topic unique id
        /// </summary>
        public Guid TopicId { get; set; }
        /// <summary>
        /// Topic title
        /// </summary>
        public string TopicTitle { get; set; }
        /// <summary>
        /// Topic type
        /// </summary>
        public string TopicType { get; set; }
        /// <summary>
        /// Topic type display name
        /// </summary>
        public string TopicTypeDisplayName { get; set; }

        /// <summary>
        /// Sequence number
        /// </summary>
        public int SequenceNumber { get; set; }

        /// <summary>
        /// Pyramid level id
        /// </summary>
        public Guid PyramidLevelId { get; set; }

        /// <summary>
        /// Pyramid level name
        /// </summary>
        public string PyramidLevelName { get; set; }
    }
}
