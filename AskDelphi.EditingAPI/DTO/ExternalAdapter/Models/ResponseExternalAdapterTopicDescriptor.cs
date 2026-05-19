namespace AskDelphi.EditingAPI.DTO.ExternalAdapter.Models
{
    public class ResponseExternalAdapterTopicDescriptor
    {
        /// <summary>
        /// Topic unique id
        /// </summary>
        public string TopicId { get; set; }
        /// <summary>
        /// Topic title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Topic status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Topic type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// The namespace of target topic
        /// </summary>
        public string Namespace { get; set; }
        /// <summary>
        /// Topic version
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Topic guid
        /// </summary>
        public Guid Guid { get; set; }
    }
}
