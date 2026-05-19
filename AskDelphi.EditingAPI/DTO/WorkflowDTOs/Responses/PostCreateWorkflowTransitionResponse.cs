namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Responses
{
    /// <summary>
    /// Response object generated after creating a new transition
    /// </summary>
    public class PostCreateWorkflowTransitionResponse
    {
        /// <summary>
        /// Id of the created transition
        /// </summary>
        public Guid TransitionId { get; set; }
    }
}
