using AskDelphi.EditingAPI.DTO.Topic.Models;

namespace AskDelphi.EditingAPI.DTO.Topic.Responses
{
    /// <summary>
    /// Response object for incoming topic relations
    /// </summary>
    public class PostSearchIncomingTopicRelationsResponse
    {
        /// <summary>
        /// Incoming topic relation information
        /// </summary>
        public PagedResult<ResponseIncomingTopicRelationSearchResult> Data { get; set; }
    }
}
