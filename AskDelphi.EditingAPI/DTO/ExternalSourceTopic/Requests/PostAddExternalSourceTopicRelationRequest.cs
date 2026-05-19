namespace AskDelphi.EditingAPI.DTO.ExternalSourceTopic.Requests
{
    public class PostAddExternalSourceTopicRelationRequest
    {
        /// <summary>
        /// Target relation topic id, path to topic in external storage
        /// </summary>
        public string TopicId { get; set; }
        /// <summary>
        /// Topic title
        /// </summary>
        public string TopicTitle { get; set; }
        /// <summary>
        /// Topic namespace
        /// </summary>
        public string Namespace { get; set; }
        /// <summary>
        /// Parent topic id
        /// </summary>
        public Guid ParentTopicId { get; set; }
        /// <summary>
        /// Relation id to parent topic
        /// </summary>
        public Guid ParentChildRelationId { get; set; }
        /// <summary>
        /// Publication id
        /// </summary>
        public Guid? PublicationId { get; set; }
        /// <summary>
        /// Adapter configuration id
        /// </summary>
        public string AdapterId { get; set; }
    }
}
