using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Requests
{
    /// <summary>
    /// Contains new status of the workflow
    /// </summary>
    public class PutUpdateWorkflowStatusRequest
    {
        /// <summary>
        /// Indicates new status of the workflow
        /// </summary>
        [Required]
        public bool Enabled { get; set; }
    }
}
