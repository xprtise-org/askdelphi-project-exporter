using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Requests
{
    public class PostApproveWorkflowTransitionRequestRequest
    {
        /// <summary>
        /// Date when changes become effective in the publication
        /// </summary>
        [Required]
        public DateTimeOffset EffectiveDate { get; set; }
    }
}
