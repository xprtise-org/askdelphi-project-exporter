using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Requests
{
    /// <summary>
    /// Request object with information about stage being moved within the worklfow and its new position among workflow stages
    /// </summary>
    public class PutMoveWorkflowStageRequest
    {
        /// <summary>
        /// Unique id of the stage that is being re-ordered withint he workflow stages
        /// </summary>
        [Required]
        public Guid StageId { get; set; }

        /// <summary>
        /// Zero-based index, indicating the new position of the stage among workflow stages
        /// </summary>
        [Required]
        public int TargetIndex { get; set; }
    }
}
