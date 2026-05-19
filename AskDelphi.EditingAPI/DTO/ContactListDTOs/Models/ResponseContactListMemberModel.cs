namespace AskDelphi.EditingAPI.DTO.ContactListDTOs.Models
{
    /// <summary>
    /// Contains model of the contact list member
    /// </summary>
    public class ResponseContactListMemberModel
    {
        /// <summary>
        /// Unique id of the contact list member
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Full name of the member
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Member email address
        /// </summary>
        public string Email { get; set; }
    }
}
