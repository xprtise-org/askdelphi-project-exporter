using AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Models;

namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Requests
{
    /// <summary>
    /// Request with steps collection, which will be used to overwrite existing request steps
    /// </summary>
    public class PutUpdateWorkflowTransitionRequestStepsRequest
    {
        /// <summary>
        /// Collection of steps
        /// </summary>
        public List<RequestWorkflowTransitionRequestStepEntryModel> Data { get; set; }
    }
}
