using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.ContactListDTOs.Models
{
    /// <summary>
    /// Contains custom members per topic stub contact list
    /// </summary>
    public class RequestTopicContactListMemberEntryModel
    {
        /// <summary>
        /// Unique id of the contact list
        /// </summary>
        [Required]
        public Guid ContactListId { get; set; }
        /// <summary>
        /// Full name of the member
        /// </summary>
        [Required]
        public string FullName { get; set; }
        /// <summary>
        /// Email of the member
        /// </summary>
        [Required]
        public string Email { get; set; }
    }
}
