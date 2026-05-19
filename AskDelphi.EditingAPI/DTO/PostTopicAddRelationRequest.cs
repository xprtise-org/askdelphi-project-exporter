namespace AskDelphi.EditingAPI.DTO
{
    public class PostTopicAddRelationRequest
    {
        public Guid RelationTypeId { get; set; }
        public Guid SourceTopicId { get; set; }
        public List<Guid> TargetTopicIds { get; set; }
    }
}
