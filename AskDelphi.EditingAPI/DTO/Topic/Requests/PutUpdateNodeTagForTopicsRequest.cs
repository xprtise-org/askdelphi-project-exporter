namespace AskDelphi.EditingAPI.DTO.Topic.Requests
{
    /// <summary>
    /// Contains information about the target node and topic ids which need to be tagged to it
    /// </summary>
    public class PutUpdateNodeTagForTopicsRequest
    {
        /// <summary>
        /// Target node id
        /// </summary>
        public string NodeId { get; set; }
        /// <summary>
        /// Collection of topic ids that need to be tagged to specified node
        /// </summary>
        public List<Guid> TopicIds { get; set; }
    }
}
