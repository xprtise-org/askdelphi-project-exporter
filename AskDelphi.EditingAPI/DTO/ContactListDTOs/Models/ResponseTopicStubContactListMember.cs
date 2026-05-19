namespace AskDelphi.EditingAPI.DTO.ContactListDTOs.Models
{
    /// <summary>
    /// Custom member per contact list
    /// </summary>
    public class ResponseTopicStubContactListMember
    {
        /// <summary>
        /// Unique id of the contact list
        /// </summary>
        public Guid ContactListId { get; set; }
        /// <summary>
        /// Full name of the member
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Email of the member
        /// </summary>
        public string Email { get; set; }
    }
}
