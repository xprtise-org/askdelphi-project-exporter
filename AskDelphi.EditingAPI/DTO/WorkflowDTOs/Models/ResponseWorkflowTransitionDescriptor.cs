namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Models
{
    /// <summary>
    /// Provides description of a workflow transition
    /// </summary>
    public class ResponseWorkflowTransitionDescriptor
    {
        /// <summary>
        /// Id of the workflow that the transition belongs to
        /// </summary>
        public Guid WorkflowId { get; set; }
        /// <summary>
        /// Title of the workflow that the transition belongs to
        /// </summary>
        public string WorkflowTitle { get; set; }
        /// <summary>
        /// Id of the transition
        /// </summary>
        public Guid TransitionId { get; set; }
        /// <summary>
        /// Transition title
        /// </summary>
        public string TransitionTitle { get; set; }
        /// <summary>
        /// Optional source stage id
        /// </summary>
        /// <remarks>
        /// When not defined, indicates that the transition applies to any stage
        /// </remarks>
        public Guid? SourceStageId { get; set; }
        /// <summary>
        /// Title of the source stage
        /// </summary>
        /// <remarks>
        /// Empty or null when <see cref="SourceStageId"/> is null
        /// </remarks>
        public string SourceStageTitle { get; set; }
        /// <summary>
        /// Target stage id for this transition
        /// </summary>
        /// <remarks>
        /// Indicates the stage at which the topics will be after the transition is complete
        /// </remarks>
        public Guid TargetStageId { get; set; }
        /// <summary>
        /// Target stage title
        /// </summary>
        public string TargetStageTitle { get; set; }
    }
}
