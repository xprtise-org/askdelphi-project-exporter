using AskDelphi.EditingAPI.DTO.Topic.Models;

namespace AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Requests
{
    /// <summary>
    /// Contains request object for checking-in a homepage topic
    /// </summary>
    public class PostCheckInHomepageTopicV2Request
    {
        /// <summary>
        /// Additional workflow actions
        /// </summary>
        public RequestTopicWorkflowActionModel WorkflowActionParameters { get; set; }
    }
}
