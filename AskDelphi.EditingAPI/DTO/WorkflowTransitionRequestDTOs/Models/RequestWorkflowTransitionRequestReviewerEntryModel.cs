namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Models
{
    /// <summary>
    /// Contains entry information used to update reviewers section of the workflow transition request
    /// </summary>
    public class RequestWorkflowTransitionRequestReviewerEntryModel
    {
        /// <summary>
        /// Updated email of the requesting user
        /// </summary>
        public string RequestByEmail { get; set; }

        /// <summary>
        /// Collection of additional reviewers
        /// </summary>
        public List<RequestWorkflowTransitionRequestReviewerEntryDetailModel> Reviewers { get; set; }
    }
}
