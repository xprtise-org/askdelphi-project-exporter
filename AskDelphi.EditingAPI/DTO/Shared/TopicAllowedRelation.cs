namespace AskDelphi.EditingAPI.DTO.Shared
{
    public class TopicAllowedRelation
    {
        public Guid PyramidLevelId { get; set; }
        public string PyramidLevelName { get; set; }
        public Guid RelationTypeId { get; set; }
        public string RelationTypeName { get; set; }
        public Guid TopicTypeId { get; set; }
        public string TopicTypeNamespace { get; set; }
        public string TopicTypeName { get; set; }
        public string TopicTypeGroupName { get; set; }
        public Guid TopicTypeGroupId { get; set; }
        public bool TopicTypeIsSupported { get; set; }
    }
}
