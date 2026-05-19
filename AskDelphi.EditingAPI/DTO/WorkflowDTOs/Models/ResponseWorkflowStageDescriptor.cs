namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Models
{
    /// <summary>
    /// Represents a simple descriptor of workflow stage
    /// </summary>
    public class ResponseWorkflowStageDescriptor
    {
        /// <summary>
        /// Unique id of the stage
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Title of the stage
        /// </summary>
        public string Title { get; set; }
    }
}
