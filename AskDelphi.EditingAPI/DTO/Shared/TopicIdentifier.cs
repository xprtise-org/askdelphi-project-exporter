namespace AskDelphi.EditingAPI.DTO.Shared
{
    /// <summary>
    /// 
    /// </summary>
    public class TopicIdentifier
    {
        public Guid TenantId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid TopicId { get; set; }
    }
}
