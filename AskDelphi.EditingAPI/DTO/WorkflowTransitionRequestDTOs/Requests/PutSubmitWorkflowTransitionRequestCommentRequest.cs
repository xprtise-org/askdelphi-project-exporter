using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Requests
{
    /// <summary>
    /// Information required to create a new comment for a workflow transition request
    /// </summary>
    public class PutSubmitWorkflowTransitionRequestCommentRequest
    {
        /// <summary>
        /// Comment in HTMl format
        /// </summary>
        [Required]
        public string Comment { get; set; }

        /// <summary>
        /// Indicates if the requester of the workflow transition request should be notified
        /// </summary>
        [Required]
        public bool NotifyRequester { get; set; }

        /// <summary>
        /// Indicates if reviewers of the workflow transition request should be notified
        /// </summary>
        [Required]
        public bool NotifyReviewers { get; set; }
    }
}
