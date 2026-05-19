using AskDelphi.EditingAPI.DTO.Topic.Models;

namespace AskDelphi.EditingAPI.DTO.Topic.Responses
{
    public class GetApplicableTransitionsForTopicVersionResponse
    {
        /// <summary>
        /// Collection of applicable transitions for a topic version, that a user has access to
        /// </summary>
        public ResponseApplicableTransitionToTopicModel Data { get; set; }
    }
}
