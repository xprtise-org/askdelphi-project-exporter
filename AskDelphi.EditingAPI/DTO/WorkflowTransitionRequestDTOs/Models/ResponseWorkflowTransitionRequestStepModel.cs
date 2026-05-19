using AskDelphi.EditingAPI.DTO.WorkflowDTOs.Models;

namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Models
{
    /// <summary>
    /// Contains information about a single workflow transition and its sequence in a workflow transition request
    /// </summary>
    public class ResponseWorkflowTransitionRequestStepModel : ResponseWorkflowTransitionDescriptor
    {
        /// <summary>
        /// Sequence of the transition (priority)
        /// </summary>
        public int SequenceNo { get; set; }
    }
}
