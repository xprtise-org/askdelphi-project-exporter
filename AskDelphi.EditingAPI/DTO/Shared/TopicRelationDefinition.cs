namespace AskDelphi.EditingAPI.DTO.Shared
{
    public class TopicRelationDefinition
    {
        public List<KeyValuePair> Metadata { get; set; }
        public Guid PyramidLevelId { get; set; }
        public string PyramidLevelName { get; set; }
        public string RelationTypeKey { get; set; }
        public string RelationTypeName { get; set; }
        public int SequenceNumber { get; set; }
        public Guid TargetTopicId { get; set; }
        public bool TargetTopicIsDeleted { get; set; }
        public string TargetTopicNamespace { get; set; }
        public string TargetTopicName { get; set; }
        public string TargetTopicType { get; set; }
        public Guid ReferenceId { get; set; }
        /// <summary>
        /// Indicates if relation is external, returned from external source and does not exist in CMS
        /// </summary>
        public bool IsContentAdapterProvided { get; set; }

        /// <summary>
        /// When set indicates the external uri for externally sourced topic
        /// </summary>
        public string ContentAdapterUri { get; set; }

        /// <summary>
        /// Indicates if target topic can be publish
        /// </summary>
        public bool DoNotPublishTargetTopic { get; set; }
    }
}
