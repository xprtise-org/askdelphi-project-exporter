namespace AskDelphi.EditingAPI.DTO.ExternalSourceTopic.Models
{
    /// <summary>
    /// Contains external source topic information, required for create topics from external sources
    /// </summary>
    public class RequestExternalSourceTopicEntryModel
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
    }
}
