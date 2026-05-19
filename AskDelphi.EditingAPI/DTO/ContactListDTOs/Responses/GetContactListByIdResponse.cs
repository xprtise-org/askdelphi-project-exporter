using AskDelphi.EditingAPI.DTO.ContactListDTOs.Models;

namespace AskDelphi.EditingAPI.DTO.ContactListDTOs.Responses
{
    /// <summary>
    /// Response with contact list model
    /// </summary>
    public class GetContactListByIdResponse
    {
        /// <summary>
        /// Contact list model
        /// </summary>
        public ResponseContactListModel Data { get; set; }
    }
}
