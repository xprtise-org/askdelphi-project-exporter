using AskDelphi.EditingAPI.DTO.WorkflowDTOs.Models;

namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Responses
{
    /// <summary>
    /// Response with workflow model
    /// </summary>
    public class GetWorkflowByIdResponse
    {
        public GetWorkflowByIdResponse()
        {
        }

        /// <summary>
        /// Workflow model
        /// </summary>
        public ResponseWorkflowModel Data { get; set; }
    }
}
