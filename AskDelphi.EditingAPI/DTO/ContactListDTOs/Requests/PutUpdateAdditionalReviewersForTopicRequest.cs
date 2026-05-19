using AskDelphi.EditingAPI.DTO.ContactListDTOs.Models;

namespace AskDelphi.EditingAPI.DTO.ContactListDTOs.Requests
{
    /// <summary>
    /// Request object with additional reviewers for topic
    /// </summary>
    public class PutUpdateAdditionalReviewersForTopicRequest
    {
        /// <summary>
        /// Optional collection of additional reviewers for topic
        /// </summary>
        public List<RequestTopicContactListMemberEntryModel> Data { get; set; }
    }
}
