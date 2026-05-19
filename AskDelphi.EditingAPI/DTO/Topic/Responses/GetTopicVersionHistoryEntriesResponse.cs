using AskDelphi.EditingAPI.DTO.Topic.Models;

namespace AskDelphi.EditingAPI.DTO.Topic.Responses
{
    /// <summary>
    /// Response object containg topic version history entries
    /// </summary>
    public class GetTopicVersionHistoryEntriesResponse
    {
        /// <summary>
        /// Topic version history entries
        /// </summary>
        public IEnumerable<ResponseTopicVersionHistoryModel> Data { get; set; }
    }
}
