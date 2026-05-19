using AskDelphi.EditingAPI.DTO.Topic.Models;

namespace AskDelphi.EditingAPI.DTO.Topic.Requests
{
    public class PostSearchIncomingTopicRelationsRequest
    {
        /// <summary>
        /// Request with incoming topic relation criteria data
        /// </summary>
        public RequestIncomingTopicRelationCriteria Data { get; set; }
    }
}
