namespace AskDelphi.EditingAPI.DTO.ContactListDTOs.Models
{
    /// <summary>
    /// Represents a simple descriptor of a contact list
    /// </summary>
    public class ResponseContactListDescriptor
    {
        /// <summary>
        /// Unique id of the contact list
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Title of the contact list
        /// </summary>
        public string Title { get; set; }
    }
}
