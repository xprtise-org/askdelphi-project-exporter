using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Models
{
    /// <summary>
    /// Params used to update workflow transition request step
    /// </summary>
    public class RequestWorkflowTransitionRequestStepEntryModel
    {
        /// <summary>
        /// Unique id of the workflow transition
        /// </summary>
        [Required]
        public Guid TransitionId { get; set; }
        /// <summary>
        /// Sequence of the workflow transition, using which the transitions will be executed once request is approved
        /// </summary>
        [Required]
        public int SequenceNo { get; set; }
    }
}
