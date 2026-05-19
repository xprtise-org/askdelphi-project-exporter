using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.ContactListDTOs.Requests
{
    /// <summary>
    /// Request object for adding a new member to contact list
    /// </summary>
    public class PutAddContactListMemberRequest
    {
        /// <summary>
        /// Email of the new member
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// Name of the new member
        /// </summary>
        [Required]
        public string MemberName { get; set; }
    }
}
