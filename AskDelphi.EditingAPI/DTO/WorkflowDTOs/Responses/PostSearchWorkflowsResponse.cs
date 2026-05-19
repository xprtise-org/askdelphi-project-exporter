using AskDelphi.EditingAPI.DTO.WorkflowDTOs.Models;

namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Responses
{
    /// <summary>
    /// Response object from searching workflows
    /// </summary>
    public class PostSearchWorkflowsResponse
    {
        public PostSearchWorkflowsResponse()
        {
        }

        /// <summary>
        /// Collection of workflow entries
        /// </summary>
        public List<ResponseWorkflowSearchResult> Data { get; set; }
    }
}
