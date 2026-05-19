namespace AskDelphi.EditingAPI.DTO.Topic.Requests
{
    public class PostTopicNewRequest
    {
        public string TopicTitle { get; set; }
        public Guid TopicTypeId { get; set; }
        public Guid? ParentTopicId { get; set; }
        public Guid? ParentTopicRelationTypeId { get; set; }
        public Guid PublicationId { get; set; }
    }
}
