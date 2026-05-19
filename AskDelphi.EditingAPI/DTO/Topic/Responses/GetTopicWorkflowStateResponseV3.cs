using AskDelphi.EditingAPI.DTO.Topic.Models;

namespace AskDelphi.EditingAPI.DTO.Topic.Responses
{
    /// <summary>
    /// Response object containing information about topic state
    /// </summary>
    public class GetTopicWorkflowStateResponseV3
    {
        /// <summary>
        /// Contains information about topic state
        /// </summary>
        public ResponseTopicStateModel Data { get; set; }

        /// <summary>
        /// Contains the error code (if any) indicating why the user is not authorised to edit the topic
        /// </summary>
        public string CanEditErrorCode { get; set; }

    }
}
