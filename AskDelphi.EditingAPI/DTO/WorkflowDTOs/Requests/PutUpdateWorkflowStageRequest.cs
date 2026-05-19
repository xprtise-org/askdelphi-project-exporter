using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Requests
{
    /// <summary>
    /// Request object containing information used to update a workflow stage
    /// </summary>
    public class PutUpdateWorkflowStageRequest
    {
        /// <summary>
        /// Indicates the update name of the workflow stage
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Indicates if workflow stage is enabled
        /// </summary>
        [Required]
        public bool Enabled { get; set; }

        /// <summary>
        /// Indicates if workflow stage is default
        /// </summary>
        [Required]
        public bool IsDefault { get; set; }
    }
}
