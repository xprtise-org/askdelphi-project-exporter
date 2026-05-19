namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Responses
{
    /// <summary>
    /// Response object generated from adding a new workflow stage
    /// </summary>
    public class PostAddWorkflowStageResponse
    {
        /// <summary>
        /// Id of the created workflow stage
        /// </summary>
        public Guid StageId { get; set; }
    }
}
