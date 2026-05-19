namespace AskDelphi.EditingAPI.DTO
{
    /// <summary>
    /// Contains information about a topic tagged to a hierarchy node
    /// </summary>
    public class ResponseTopicTaggedToHierarchy
    {
        /// <summary>
        /// The id of the node to which the topic is tagged
        /// </summary>
        public string NodeId { get; set; }
        /// <summary>
        /// The topic guid
        /// </summary>
        public Guid TopicGuid { get; set; }
        /// <summary>
        /// The namespace of the topic
        /// </summary>
        public string TopicNamespace { get; set; }
        /// <summary>
        /// The title of the topic
        /// </summary>
        public string TopicTitle { get; set; }
    }
}
