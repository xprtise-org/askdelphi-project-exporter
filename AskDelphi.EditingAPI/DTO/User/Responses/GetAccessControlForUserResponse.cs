using AskDelphi.EditingAPI.DTO.User.Models;

namespace AskDelphi.EditingAPI.DTO.User.Responses
{
    /// <summary>
    /// Response object containing access control entries applicable to user for a project
    /// </summary>
    public class GetAccessControlForUserResponse
    {
        /// <summary>
        /// Access control entries
        /// </summary>
        public List<ResponseAccessControlModel> Data { get; set; }
    }
}
