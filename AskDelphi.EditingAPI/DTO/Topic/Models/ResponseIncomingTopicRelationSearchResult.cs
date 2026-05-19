namespace AskDelphi.EditingAPI.DTO.Topic.Models
{
    /// <summary>
    /// Contains information about a single incoming topic relation for a topic
    /// </summary>
    public class ResponseIncomingTopicRelationSearchResult
    {
        /// <summary>
        /// Id of the incoming relation target topic
        /// </summary>
        public Guid TargetTopicId { get; set; }
        /// <summary>
        /// Id of the incoming relation target topic version
        /// </summary>
        public Guid TopicVersionId { get; set; }
        /// <summary>
        /// Incoming relation topic type title
        /// </summary>
        public string TopicType { get; set; }
        /// <summary>
        /// Incoming relation topic title
        /// </summary>
        public string TopicTitle { get; set; }

        /// <summary>
        /// Complete version number of the incoming relation
        /// </summary>
        public string VersionNo { get; set; }
        /// <summary>
        /// Incoming relation relation type display name
        /// </summary>
        public string RelationTypeDisplayName { get; set; }
        /// <summary>
        /// Incoming relation pyramid level display name
        /// </summary>
        public string PyramidLevelDisplayName { get; set; }
        /// <summary>
        /// Workflow stage of the incoming relation (E.g. draft/staging/published)
        /// </summary>
        public string WorkflowStage { get; set; }
    }
}
