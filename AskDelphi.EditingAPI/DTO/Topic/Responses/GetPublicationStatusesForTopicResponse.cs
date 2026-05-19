using AskDelphi.EditingAPI.DTO.Topic.Models;

namespace AskDelphi.EditingAPI.DTO.Topic.Responses
{
    /// <summary>
    /// Response object with publication statuses for topic
    /// </summary>
    public class GetPublicationStatusesForTopicResponse
    {
        /// <summary>
        /// Contains publication statuses for topic
        /// </summary>
        public IEnumerable<ResponsePublicationTopicSummary> Data { get; set; }
    }
}
