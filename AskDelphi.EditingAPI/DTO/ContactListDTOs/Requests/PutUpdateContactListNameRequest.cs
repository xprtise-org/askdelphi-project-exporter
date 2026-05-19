using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.ContactListDTOs.Requests
{
    /// <summary>
    /// Request object to update contact list name
    /// </summary>
    public class PutUpdateContactListNameRequest
    {
        /// <summary>
        /// New name of the contact list
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
