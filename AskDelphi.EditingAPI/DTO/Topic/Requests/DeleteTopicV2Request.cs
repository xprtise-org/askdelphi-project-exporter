namespace AskDelphi.EditingAPI.DTO.Topic.Requests
{
    /// <summary>
    /// Additional information for delete request
    /// </summary>
    public class DeleteTopicV2Request
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
    }
}
