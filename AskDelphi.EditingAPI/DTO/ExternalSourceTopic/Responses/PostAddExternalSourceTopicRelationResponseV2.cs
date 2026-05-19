using AskDelphi.EditingAPI.DTO.ExternalSourceTopic.Models;

namespace AskDelphi.EditingAPI.DTO.ExternalSourceTopic.Responses
{
    /// <summary>
    /// Contains collection of topics and their status, with regards to adding them as a relation to parent topic
    /// </summary>
    public class PostAddExternalSourceTopicRelationResponseV2
    {
        /// <summary>
        /// Collection of topics and their status
        /// </summary>
        public IEnumerable<ResponseExternalSourceTopicRelationEntryResult> Data { get; set; }
    }
}
