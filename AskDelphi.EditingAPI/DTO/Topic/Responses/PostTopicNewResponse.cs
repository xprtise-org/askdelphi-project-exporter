namespace AskDelphi.EditingAPI.DTO.Topic.Responses
{
    public class PostTopicNewResponse
    {
        public PostTopicNewResponse()
        {
        }
        public PostTopicNewResponse(Guid responseTopicId, Guid responseTopicVersionKey)
        {
            TopicId = responseTopicId;
            TopicVersionKey = responseTopicVersionKey;
        }

        public Guid TopicId { get; set; }
        public Guid TopicVersionKey { get; set; }
    }
}
