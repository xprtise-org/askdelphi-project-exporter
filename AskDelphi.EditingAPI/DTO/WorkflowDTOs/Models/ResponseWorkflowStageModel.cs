namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Models
{
    /// <summary>
    /// Represents a single workflow stage definition
    /// </summary>
    public class ResponseWorkflowStageModel
    {
        /// <summary>
        /// Unique id of the stage
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Title of the stage
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Indicates if stage is enabled
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// Indicates if stage is a default stage
        /// </summary>
        public bool IsDefault { get; set; }
        /// <summary>
        /// Indicates the sequence no of the stage among other stages in the workflow
        /// </summary>
        public int SequenceNo { get; set; }
        /// <summary>
        /// If of the workflow that this stage belongs to
        /// </summary>
        public Guid WorkflowId { get; set; }
    }
}
