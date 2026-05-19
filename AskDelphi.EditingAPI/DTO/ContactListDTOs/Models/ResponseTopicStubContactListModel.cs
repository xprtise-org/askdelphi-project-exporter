namespace AskDelphi.EditingAPI.DTO.ContactListDTOs.Models
{
    /// <summary>
    /// Contains defined custom members for each project contact list
    /// </summary>
    public class ResponseTopicStubContactListModel
    {
        /// <summary>
        /// All enabled contact lists for a project
        /// </summary>
        public List<ResponseContactListDescriptor> ProjectContactLists { get; set; }
        /// <summary>
        /// Custom members defined for each contact list
        /// </summary>
        public List<ResponseTopicStubContactListMember> CustomMembers { get; set; }
    }
}
