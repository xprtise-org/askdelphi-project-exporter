using AskDelphi.EditingAPI.DTO.WorkflowDTOs.Models;
using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Requests
{
    /// <summary>
    /// Request object with transition definition
    /// </summary>
    public class PutUpdateWorkflowTransitionRequest
    {
        /// <summary>
        /// Contains definition of updated transition
        /// </summary>
        [Required]
        public RequestWorkflowTransitionEntryModel Data { get; set; }
    }
}
