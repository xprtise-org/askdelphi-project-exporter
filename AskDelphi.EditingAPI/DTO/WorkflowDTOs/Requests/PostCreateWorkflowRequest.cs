using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Requests
{
    /// <summary>
    /// Request object with name of the workflow
    /// </summary>
    public class PostCreateWorkflowRequest
    {
        /// <summary>
        /// Name of the new workflow
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
