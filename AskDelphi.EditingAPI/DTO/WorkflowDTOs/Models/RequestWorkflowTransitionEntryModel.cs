using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Models
{
    /// <summary>
    /// Params used for creating/updating workflow transitions
    /// </summary>
    public class RequestWorkflowTransitionEntryModel
    {
        /// <summary>
        /// Name of transition
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Optional source stage, when not specified will be applied to all stages
        /// </summary>
        public Guid? SourceStageId { get; set; }
        /// <summary>
        /// Target stage
        /// </summary>
        [Required]
        public Guid TargetStageId { get; set; }
        /// <summary>
        /// Indicates if transition is enabled
        /// </summary>
        [Required]
        public bool Enabled { get; set; }
        /// <summary>
        /// Indicates if transition is only available to admins
        /// </summary>
        [Required]
        public bool OnlyAdmins { get; set; }
        /// <summary>
        /// Indicates if source stage will be removed and replaced with target stage
        /// </summary>
        [Required]
        public bool ClearSourceStage { get; set; }
        /// <summary>
        /// Optional approval list id
        /// </summary>
        public Guid? ContactListId { get; set; }
    }
}
