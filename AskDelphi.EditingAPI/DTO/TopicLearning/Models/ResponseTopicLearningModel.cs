namespace AskDelphi.EditingAPI.DTO.TopicLearning.Models
{
    public class ResponseTopicLearningModel
    {
        /// <summary>
        /// Object containing information about topic learning quiz
        /// </summary>
        public ResponseTopicLearningCompletionQuizModel CompletionQuiz { get; set; }
        /// <summary>
        /// Collection of quiz questions for this topic learning
        /// </summary>
        public IEnumerable<ResponseTopicLearningQuizQuestion> QuizQuestions { get; set; }
        /// <summary>
        /// Indicates whether users may add all items to the learning plan
        /// </summary>
        public bool SupportUserAddAll { get; set; }
        /// <summary>
        /// Topic learning description
        /// </summary>
        public string DescriptionHTML { get; set; }
    }
}
