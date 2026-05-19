using AskDelphi.EditingAPI.DTO.ExternalSourceTopic.Models;

namespace AskDelphi.EditingAPI.DTO.ExternalSourceTopic.Requests
{
    /// <summary>
    /// Contains information about external source topics and parent topic, used to add relations to parent topic
    /// </summary>
    public class PostAddExternalSourceTopicRelationRequestV2
    {
        /// <summary>
        /// Contains external source topic information, used to create relations to parent topic
        /// </summary>
        public IEnumerable<RequestExternalSourceTopicRelationEntryModel> Data { get; set; }
        /// <summary>
        /// Parent topic id
        /// </summary>
        public Guid ParentTopicId { get; set; }
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
