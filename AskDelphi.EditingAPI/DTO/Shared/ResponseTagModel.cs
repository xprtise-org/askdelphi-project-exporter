namespace AskDelphi.EditingAPI.DTO.Shared
{
    public class ResponseTagModel : ResponseTagModelBase
    {

        /// <summary>
        /// TagId is the TopicRelationGuid from TopicDetails.OutgoingRelations
        /// </summary>
        public Guid TagId { get; set; }

        /// <summary>
        /// True if the tag is enforced by the operationContext's ACL entry
        /// </summary>
        public bool EnforcedByAcl { get; set; }

        /// <summary>
        /// True when the tag can be used to filter the topic list on.
        /// </summary>
        public bool IsTopicListFilter { get; set; }
    }
}
