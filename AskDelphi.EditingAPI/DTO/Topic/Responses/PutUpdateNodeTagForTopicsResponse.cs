using AskDelphi.EditingAPI.DTO.Topic.Models;

namespace AskDelphi.EditingAPI.DTO.Topic.Responses
{
    /// <summary>
    /// Response object returned from tagging topics to single node
    /// Contains the tagging result that the user requested
    /// </summary>
    public class PutUpdateNodeTagForTopicsResponse
    {
        /// <summary>
        /// List of topics that are processed with corresponding statuses
        /// </summary>
        public IEnumerable<ResponseTopicTagResult> TopicTagResults { get; set; }
    }


}
