using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.ContactListDTOs.Requests
{
    /// <summary>
    /// Request object with name of the contact list
    /// </summary>
    public class PostCreateContactListRequest
    {
        /// <summary>
        /// Name of the new contact list
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
