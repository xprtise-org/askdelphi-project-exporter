using AskDelphi.EditingAPI.DTO.Topic.Models;

namespace AskDelphi.EditingAPI.DTO.Topic.Responses
{
    public class PostSearchTopicVersionHistoryTableResponse
    {
        /// <summary>
        /// Topic version table entries
        /// </summary>
        public List<ResponseTopicVersionHistoryTableModel> Data { get; set; }
    }
}
