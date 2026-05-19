using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Models
{
    /// <summary>
    /// Params used to update existing request reviewers
    /// </summary>
    public class RequestWorkflowTransitionRequestReviewerEntryDetailModel
    {
        /// <summary>
        /// Name of the reviewer
        /// </summary>
        [Required]
        public string ReviewerName { get; set; }
        /// <summary>
        /// Email of the reviewer
        /// </summary>
        [Required]
        public string ReviewerEmail { get; set; }
    }
}
