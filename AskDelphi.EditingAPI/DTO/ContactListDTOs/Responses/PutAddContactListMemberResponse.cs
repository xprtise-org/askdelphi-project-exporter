namespace AskDelphi.EditingAPI.DTO.ContactListDTOs.Responses
{
    /// <summary>
    /// Response object from adding a new member to the contact list
    /// </summary>
    public class PutAddContactListMemberResponse
    {
        /// <summary>
        /// Unique id of the new member
        /// </summary>
        public Guid MemberId { get; set; }
    }
}
