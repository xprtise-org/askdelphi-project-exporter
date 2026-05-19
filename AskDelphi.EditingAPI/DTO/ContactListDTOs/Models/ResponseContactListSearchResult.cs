namespace AskDelphi.EditingAPI.DTO.ContactListDTOs.Models
{
    /// <summary>
    /// Contains information about a single contact list search result
    /// </summary>
    public class ResponseContactListSearchResult
    {
        /// <summary>
        /// Unique id of the contact list
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Name of the contact list
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Number of members defined for the contact list
        /// </summary>
        public int MemberCount { get; set; }
    }
}
