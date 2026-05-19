using AskDelphi.EditingAPI.DTO.TopicLearning.Models;

namespace AskDelphi.EditingAPI.DTO.TopicLearning.Requests
{
    public class PutUpdateTopicLearningQuizQuestionsRequest
    {
        /// <summary>
        /// Collection of quiz questions for this topic learning
        /// </summary>
        public IEnumerable<RequestTopicLearningQuizQuestion> QuizQuestions { get; set; }
    }
}
