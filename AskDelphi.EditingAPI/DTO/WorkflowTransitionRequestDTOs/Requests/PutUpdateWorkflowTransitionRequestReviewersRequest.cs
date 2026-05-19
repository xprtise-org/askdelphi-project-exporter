using AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Models;

namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Requests
{
    /// <summary>
    /// Request with reviewers collection, which will be used to overwrite existing request reviewers
    /// </summary>
    public class PutUpdateWorkflowTransitionRequestReviewersRequest
    {
        /// <summary>
        /// Collection of reviewers and requesters updated email address
        /// </summary>
        public RequestWorkflowTransitionRequestReviewerEntryModel Data { get; set; }
    }
}
