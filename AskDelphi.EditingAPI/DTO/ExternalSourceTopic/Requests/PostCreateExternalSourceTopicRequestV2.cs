using AskDelphi.EditingAPI.DTO.ExternalSourceTopic.Models;

namespace AskDelphi.EditingAPI.DTO.ExternalSourceTopic.Requests
{
    /// <summary>
    /// Contains information required to create topics from external source
    /// </summary>
    public class PostCreateExternalSourceTopicRequestV2
    {
        /// <summary>
        /// Publication id
        /// </summary>
        public Guid? PublicationId { get; set; }
        /// <summary>
        /// Adapter configuration id
        /// </summary>
        public string AdapterId { get; set; }

        /// <summary>
        /// Collection of external source topics
        /// </summary>
        public IEnumerable<RequestExternalSourceTopicEntryModel> Data { get; set; }
    }
}
