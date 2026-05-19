using AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Models;

namespace AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Responses
{
    /// <summary>
    /// Contains homepage topic tab descriptor information
    /// </summary>
    public class GetHomepageTopicTabDescriptorsResponse
    {
        /// <summary></summary>
        /// <summary>
        /// Contains descriptor information about homepage topic tabs
        /// </summary>
        public IEnumerable<ResponseHomepageTopicTabDescriptor> Data { get; set; }
    }
}
