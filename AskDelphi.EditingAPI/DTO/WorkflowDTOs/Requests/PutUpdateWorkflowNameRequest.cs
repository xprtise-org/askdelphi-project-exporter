using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Requests
{
    /// <summary>
    /// Contains new name of the workflow
    /// </summary>
    public class PutUpdateWorkflowNameRequest
    {
        /// <summary>
        /// Indicates new name of the workflow
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
