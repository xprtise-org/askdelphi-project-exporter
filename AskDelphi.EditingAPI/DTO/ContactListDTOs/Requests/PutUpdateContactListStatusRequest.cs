using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.ContactListDTOs.Requests
{
    /// <summary>
    /// Contains new status of the contact list
    /// </summary>
    public class PutUpdateContactListStatusRequest
    {
        /// <summary>
        /// Indicates if contact list is marked as enabled or disabled
        /// </summary>
        [Required]
        public bool Enabled { get; set; }
    }
}
