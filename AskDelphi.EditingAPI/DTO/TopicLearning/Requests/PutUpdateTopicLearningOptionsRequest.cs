using AskDelphi.EditingAPI.DTO.TopicLearning.Models;

namespace AskDelphi.EditingAPI.DTO.TopicLearning.Requests
{
    public class PutUpdateTopicLearningOptionsRequest
    {
        /// <summary>
        /// Object containing information about topic learning quiz
        /// </summary>
        public RequestTopicLearningCompletionQuizModel Data { get; set; }
        /// <summary>
        /// Indicates whether users may add all items to the learning plan
        /// </summary>
        public bool SupportUserAddAll { get; set; }
    }
}
