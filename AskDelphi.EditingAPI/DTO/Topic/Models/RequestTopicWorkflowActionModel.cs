namespace AskDelphi.EditingAPI.DTO.Topic.Models
{
    /// <summary>
    /// Contains additional workflow actions a user can take when performing, check-in or delete topic operations
    /// </summary>
    public class RequestTopicWorkflowActionModel
    {
        /// <summary>
        /// Selected workflow stage ids
        /// </summary>
        /// <remarks>
        /// These are stages that the parent topic version has and thus a can be selected from and assigned to the checked-in topic version
        /// </remarks>
        public List<Guid> ApplyWorkflowStageIds { get; set; }

        /// <summary>
        /// Selected workflow transition ids
        /// </summary>
        /// <remarks>
        /// Foreach of the specified transitions the checked-in version will be transitioned to target stage
        /// </remarks>
        public List<Guid> ApplyWorkflowTransitionIds { get; set; }

        /// <summary>
        /// When set, the major version no will be increased to the next available version no for this topic
        /// </summary>
        public bool IncreaseMajorVersionNo { get; set; }
    }
}
