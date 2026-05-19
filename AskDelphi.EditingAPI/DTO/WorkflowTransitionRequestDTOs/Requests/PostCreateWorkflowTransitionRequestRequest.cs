namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Requests
{
    /// <summary>
    /// Set of params required to create a workflow transition request
    /// </summary>
    public class PostCreateWorkflowTransitionRequestRequest
    {
        /// <summary>
        /// Title of the request
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Description of the request
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Indicates the date when the transition should go live
        /// </summary>
        public DateTime CompleteByDate { get; set; }
        /// <summary>
        /// Complete url to the request in format /../{requestId}
        /// </summary>
        /// <remarks>
        /// {requestId} is a place holder and is replaced by the generated request id
        /// </remarks>
        public string Url { get; set; }
    }
}
