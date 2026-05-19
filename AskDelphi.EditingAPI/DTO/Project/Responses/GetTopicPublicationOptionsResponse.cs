using AskDelphi.EditingAPI.DTO.Project.Models;

namespace AskDelphi.EditingAPI.DTO.Project.Responses
{
    /// <summary>
    /// Contains available project publications that a topic can be published to
    /// </summary>
    public class GetTopicPublicationOptionsResponse
    {
        /// <summary>
        /// Contains publication information
        /// </summary>
        public IEnumerable<ResponseTopicPublicationOptionModel> Data { get; set; }
    }
}
