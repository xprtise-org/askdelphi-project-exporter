namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Models
{
    /// <summary>
    /// Contains comment information
    /// </summary>
    public class ResponseWorkflowTransitionRequestCommentDescriptor
    {
        /// <summary>
        /// Comment in HTML format
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Date the comment was submitted
        /// </summary>
        public DateTime DateSubmitted { get; set; }

        /// <summary>
        /// Formatted <see cref="DateSubmitted"/> in yyyy-MM-dd string
        /// </summary>
        public string DateSubmittedFmt => $"{DateSubmitted:yyyy-MM-dd}";
        /// <summary>
        /// Full name of the user who submitted the comment
        /// </summary>
        public string SubmittedByName { get; set; }
    }
}
