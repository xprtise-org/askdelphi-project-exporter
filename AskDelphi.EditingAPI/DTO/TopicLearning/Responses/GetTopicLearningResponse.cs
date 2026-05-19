using AskDelphi.EditingAPI.DTO.TopicLearning.Models;

namespace AskDelphi.EditingAPI.DTO.TopicLearning.Responses
{
    /// <summary>
    /// Response containing information about the topic learning
    /// </summary>
    public class GetTopicLearningResponse
    {
        /// <summary>
        /// Topic learning model
        /// </summary>
        public ResponseTopicLearningModel Data { get; set; }
    }
}
