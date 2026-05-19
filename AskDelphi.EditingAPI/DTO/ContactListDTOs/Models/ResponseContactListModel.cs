namespace AskDelphi.EditingAPI.DTO.ContactListDTOs.Models
{
    /// <summary>
    /// Contains model of the contact list
    /// </summary>
    public class ResponseContactListModel
    {
        /// <summary>
        /// Unique id of the contact list
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Title of the contact list
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Indicates if contact list is enabled
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Members of the contact list
        /// </summary>
        public List<ResponseContactListMemberModel> Members { get; set; }
    }
}
