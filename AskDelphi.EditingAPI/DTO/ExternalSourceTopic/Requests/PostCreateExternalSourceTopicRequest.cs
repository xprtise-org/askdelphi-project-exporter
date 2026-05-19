namespace AskDelphi.EditingAPI.DTO.ExternalSourceTopic.Requests
{
    public class PostCreateExternalSourceTopicRequest
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
        /// Publication id
        /// </summary>
        public Guid? PublicationId { get; set; }
        /// <summary>
        /// Adapter configuration id
        /// </summary>
        public string AdapterId { get; set; }
    }
}
