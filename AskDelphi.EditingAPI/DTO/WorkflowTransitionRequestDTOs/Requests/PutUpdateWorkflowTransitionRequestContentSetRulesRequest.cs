using AskDelphi.EditingAPI.DTO.Shared.Models;

namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Requests
{
    /// <summary>
    /// Request with content set rules json definition
    /// </summary>
    public class PutUpdateWorkflowTransitionRequestContentSetRulesRequest
    {
        /// <summary>
        /// Content set rules
        /// </summary>
        public List<RequestContentSetRuleModel> Rules { get; set; }
    }
}
