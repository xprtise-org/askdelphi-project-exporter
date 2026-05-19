using AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Models;

namespace AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Requests
{
    /// <summary>
    /// Contains updated tab content information
    /// </summary>
    public class PostStoreHomepageTabContentRequest
    {
        /// <summary>
        /// Tab content information
        /// </summary>
        public RequestHomepageTabContentUpdateModel Data { get; set; }
    }
}
