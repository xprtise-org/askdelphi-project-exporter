using AskDelphi.EditingAPI.DTO.WorkflowDTOs.Models;
using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Requests
{
    /// <summary>
    /// Request object with transition definition
    /// </summary>
    public class PostCreateWorkflowTransitionRequest
    {
        /// <summary>
        /// Contains definition of new transition
        /// </summary>
        [Required]
        public RequestWorkflowTransitionEntryModel Data { get; set; }
    }
}
