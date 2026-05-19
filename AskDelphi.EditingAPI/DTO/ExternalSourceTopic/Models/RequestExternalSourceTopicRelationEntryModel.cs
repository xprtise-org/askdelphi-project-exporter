namespace AskDelphi.EditingAPI.DTO.ExternalSourceTopic.Models
{
    /// <summary>
    /// Contains external source topic information, used to create relations to parent topic
    /// </summary>
    public class RequestExternalSourceTopicRelationEntryModel
    {
        /// <summary>
        /// Topic id, path to topic in external storage
        /// </summary>
        public string TopicId { get; set; }
        /// <summary>
        /// External source topic title
        /// </summary>
        public string TopicTitle { get; set; }
        /// <summary>
        /// External source topic namespace
        /// </summary>
        public string Namespace { get; set; }
        /// <summary>
        /// Relation id to parent topic
        /// </summary>
        public Guid ParentChildRelationId { get; set; }
    }
}
