namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Models
{
    /// <summary>
    /// Contains information about a single workflow transition request search result
    /// </summary>
    public class ResponseWorkflowTransitionRequestSearchResult
    {
        /// <summary>
        /// Unique id of the request
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Title of the request
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Indicates if request was approved
        /// </summary>
        public bool Approved { get; set; }
        /// <summary>
        /// Indicates the date when the transition should go live
        /// </summary>
        public DateTime CompletionDate { get; set; }

        /// <summary>
        /// Formatted <see cref="CompletionDate"/> in yyyy-MM-dd string
        /// </summary>
        public string CompletionDateFmt => $"{CompletionDate:yyyy-MM-dd}";
    }
}
