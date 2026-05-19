using KeyValuePair = AskDelphi.EditingAPI.DTO.Shared.KeyValuePair;

namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Models
{
    /// <summary>
    /// Contains reviewers defined for this workflow transition request
    /// </summary>
    public class ResponseWorkflowTransitionRequestReviewersModel : ResponseWorkflowTransitionRequestBaseModel
    {
        /// <summary>
        /// Indicates the email of the user that created the request
        /// </summary>
        public string RequestedByUserEmail { get; set; }
        /// <summary>
        /// Collection of reviewers defined for this request
        /// </summary>
        /// <remarks>
        /// Where key is the name of the reviewer, while value is the email
        /// </remarks>
        public List<KeyValuePair> Reviewers { get; set; }

        /// <summary>
        /// Collection of approver groups defined for all transitions, defined for this worklfow transiton request
        /// </summary>
        public List<string> ApproverGroups { get; set; }
    }
}
