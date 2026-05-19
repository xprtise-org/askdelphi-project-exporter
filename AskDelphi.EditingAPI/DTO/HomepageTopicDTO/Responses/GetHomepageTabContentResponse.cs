using AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Models;

namespace AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Responses
{
    /// <summary>
    /// Contains configuration and details of requested homepage tab
    /// </summary>
    public class GetHomepageTabContentResponse
    {
        /// <summary>
        /// Contains groups and columns, defined by user for a homepage tab
        /// </summary>
        public ResponseHomepageTabContentModel Data { get; set; }
    }
}
