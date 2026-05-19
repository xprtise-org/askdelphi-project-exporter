using AskDelphi.EditingAPI.DTO.WorkflowDTOs.Models;

namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Models
{
    /// <summary>
    /// Contains transitions model of workflow transition request
    /// </summary>
    public class ResponseWorkflowTransitionRequestTransitionsModel : ResponseWorkflowTransitionRequestBaseModel
    {
        /// <summary>
        /// Selected transitions for this request
        /// </summary>
        public List<ResponseWorkflowTransitionRequestStepModel> SelectedTransitions { get; set; }
        /// <summary>
        /// All existing transitions, that can be selected from
        /// </summary>
        public List<ResponseWorkflowTransitionDescriptor> ExistingTransitions { get; set; }
    }
}
