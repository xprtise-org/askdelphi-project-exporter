namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Responses
{
    /// <summary>
    /// Response object of creating the workflow
    /// </summary>
    public class PostCreateWorkflowResponse
    {
        /// <summary>
        /// Id of the created workflow
        /// </summary>
        public Guid WorkflowId { get; set; }
    }
}
