using AskDelphi.EditingAPI.DTO.User.Models;

namespace AskDelphi.EditingAPI.DTO.User.Responses
{
    public class GetEditingAccessControlForUserResponse
    {
        /// <summary>
        /// Access control entries
        /// </summary>
        public List<ResponseAccessControlModel> Data { get; set; }
    }
}
