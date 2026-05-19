using AskDelphi.EditingAPI.DTO.Topic.Models;

namespace AskDelphi.EditingAPI.DTO.Topic.Responses
{
    /// <summary>
    /// Response object containing topic details at two versions
    /// </summary>
    public class PostTopicVersionComparisonResponse
    {

        /// <summary>
        /// Topic details at version
        /// </summary>
        public ResponseTopicVersionDetails Version1 { get; set; }
        /// <summary>
        /// Topic details at version
        /// </summary>
        public ResponseTopicVersionDetails Version2 { get; set; }
    }
}
