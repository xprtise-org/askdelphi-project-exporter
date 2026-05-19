namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Responses
{
    /// <summary>
    /// Contains information about created request
    /// </summary>
    public class PostCreateWorkflowTransitionRequestResponse
    {
        /// <summary>
        /// Unique id of the created request
        /// </summary>
        public Guid RequestId { get; set; }
    }
}
