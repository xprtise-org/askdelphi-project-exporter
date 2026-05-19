namespace AskDelphi.EditingAPI.DTO
{
    public class DeleteTopicRelationRequest
    {
        public Guid RelationTypeId { get; set; }
        public Guid SourceTopicId { get; set; }
        public Guid TargetTopicId { get; set; }
    }
}
