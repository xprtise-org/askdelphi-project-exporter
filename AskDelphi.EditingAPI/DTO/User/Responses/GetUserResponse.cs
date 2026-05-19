using AskDelphi.EditingAPI.DTO.User.Models;

namespace AskDelphi.EditingAPI.DTO.User.Responses
{
    /// <summary>
    /// Response object containing user information
    /// </summary>
    public class GetUserResponse
    {
        /// <summary>
        /// User ID and user name
        /// </summary>
        public ResponseUserModel Data { get; set; }

    }
}