using AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Models;

namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Responses
{
    /// <summary>
    /// Contains mathing topics response
    /// </summary>
    public class GetWorkflowTransitionRequestMatchingTopicsResponse
    {
        /// <summary>
        /// Contains collection of matching topics for this workflow transition request
        /// </summary>
        public List<ResponseWorkflowTransitionRequestMatchingTopicDisplayModel> Data { get; set; }
    }
}
