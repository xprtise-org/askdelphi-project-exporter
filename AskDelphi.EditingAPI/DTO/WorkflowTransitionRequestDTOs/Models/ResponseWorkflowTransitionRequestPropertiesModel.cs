namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Models
{
    /// <summary>
    /// Contains properties model of workflow transition request
    /// </summary>
    public class ResponseWorkflowTransitionRequestPropertiesModel : ResponseWorkflowTransitionRequestBaseModel
    {
        /// <summary>
        /// Description of the transition request
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Indicates the date when the changes should go live
        /// </summary>
        public DateTime CompleteByDate { get; set; }
    }
}
