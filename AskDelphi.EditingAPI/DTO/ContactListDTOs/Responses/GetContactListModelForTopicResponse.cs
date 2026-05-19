using AskDelphi.EditingAPI.DTO.ContactListDTOs.Models;

namespace AskDelphi.EditingAPI.DTO.ContactListDTOs.Responses
{
    /// <summary>
    /// Response with contact list members per topic
    /// </summary>
    public class GetContactListModelForTopicResponse
    {
        /// <summary>
        /// Contact list member per topic
        /// </summary>
        public ResponseTopicStubContactListModel Data { get; set; }
    }
}
