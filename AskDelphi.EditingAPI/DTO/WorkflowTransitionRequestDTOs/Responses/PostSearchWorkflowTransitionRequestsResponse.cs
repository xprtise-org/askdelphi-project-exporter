using AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Models;

namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Responses
{
    /// <summary>
    /// Response object with workflow transition requests for specified project
    /// </summary>
    public class PostSearchWorkflowTransitionRequestsResponse
    {
        /// <summary>
        /// Collection of worklfow transition requests for specified project
        /// </summary>
        public List<ResponseWorkflowTransitionRequestSearchResult> Data { get; set; }
    }
}
