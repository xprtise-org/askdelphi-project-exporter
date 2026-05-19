namespace AskDelphi.EditingAPI.DTO.ContactListDTOs.Responses
{
    /// <summary>
    /// Response object of creating the contact list
    /// </summary>
    public class PostCreateContactListResponse
    {
        /// <summary>
        /// Id of the created contact list
        /// </summary>
        public Guid ContactListId { get; set; }
    }
}
