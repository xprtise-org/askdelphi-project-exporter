using AskDelphi.EditingAPI.DTO.ContactListDTOs.Models;

namespace AskDelphi.EditingAPI.DTO.ContactListDTOs.Responses
{
    /// <summary>
    /// Response object for searching contact list
    /// </summary>
    public class PostSearchContactListResponse
    {
        /// <summary>
        /// Collection of contact list entries
        /// </summary>
        public List<ResponseContactListSearchResult> Data { get; set; }
    }
}
