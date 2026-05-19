namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Models
{
    /// <summary>
    /// Model containing information about a workflow transition, when used to create selectors (checkboxes, dropdowns)
    /// </summary>
    public class ResponseWorkflowTransitionSelector
    {
        /// <summary>
        /// Unique id of the workflow transition
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Title of the workflow transition
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Target stage id of this transition
        /// </summary>
        public Guid TargetStageId { get; set; }
        /// <summary>
        /// Target stage title of this transition
        /// </summary>
        public string TargetStageTitle { get; set; }
        /// <summary>
        /// Indicates that the target stage in this transition is used as default editing stage
        /// </summary>
        public bool IsTargetStageIsDefaultEditingStage { get; set; }
    }
}
