using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Requests
{
    /// <summary>
    /// Request object containing information about a new workflow stage
    /// </summary>
    public class PostAddWorkflowStageRequest
    {
        /// <summary>
        /// Indicates the name of the new workflow stage
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
