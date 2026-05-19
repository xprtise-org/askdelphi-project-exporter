namespace AskDelphi.EditingAPI.DTO.Topic.Responses
{
    /// <summary>
    /// Repsonse with topic version id
    /// </summary>
    public class PostCalculateTopicVersionIdforVersionNoResponse(Guid topicVersionId)
    {

        /// <summary>
        /// Unique id of the topic version
        /// </summary>
        public Guid TopicVersionId { get; set; } = topicVersionId;
    }
}
