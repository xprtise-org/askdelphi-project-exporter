namespace AskDelphi.EditingAPI.DTO.ExternalSourceTopic.Responses
{
    public class PostCreateExternalSourceTopicResponse(Guid source)
    {
        public Guid TopicId { get; set; } = source;
    }
}
