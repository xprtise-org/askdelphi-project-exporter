using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Requests
{
    public class PostCreateWorkflowTransitionRequestForTopicRequest
    {
        /// <summary>
        /// Complete url to the request in format /../{requestId}
        /// </summary>
        /// <remarks>
        /// {requestId} is a place holder and is replaced by the generated request id
        /// </remarks>
        [Required]
        public string Url { get; set; }
    }
}
