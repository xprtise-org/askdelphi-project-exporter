namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Models
{
    /// <summary>
    /// Contains comments submitted for a workflow transition request
    /// </summary>
    public class ResponseWorkflowTransitionRequestCommentModel : ResponseWorkflowTransitionRequestBaseModel
    {
        /// <summary>
        /// Collection of comments
        /// </summary>
        public List<ResponseWorkflowTransitionRequestCommentDescriptor> Comments { get; set; }
    }
}
