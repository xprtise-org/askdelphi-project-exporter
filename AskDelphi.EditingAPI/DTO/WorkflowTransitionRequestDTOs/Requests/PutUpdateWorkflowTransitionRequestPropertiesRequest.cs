using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Requests
{
    /// <summary>
    /// Request object with basic properties, that can be used to udpate an existing workflow transition request
    /// </summary>
    public class PutUpdateWorkflowTransitionRequestPropertiesRequest
    {
        /// <summary>
        /// New title
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// New description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// New 'complete by date'
        /// </summary>
        [Required]
        public DateTime CompleteByDate { get; set; }
    }
}
