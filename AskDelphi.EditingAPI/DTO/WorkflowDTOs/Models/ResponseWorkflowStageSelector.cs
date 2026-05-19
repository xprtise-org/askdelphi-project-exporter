namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Models
{
    /// <summary>
    /// Model containing information about a workflow stage, when used to create selectors (checkboxes, dropdowns)
    /// </summary>
    public class ResponseWorkflowStageSelector
    {
        /// <summary>
        /// Unique id of the workflow stage
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Title of the workflow stage
        /// </summary>
        public string Title { get; set; }
    }
}
