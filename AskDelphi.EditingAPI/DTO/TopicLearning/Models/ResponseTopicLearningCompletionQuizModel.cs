namespace AskDelphi.EditingAPI.DTO.TopicLearning.Models
{
    public class ResponseTopicLearningCompletionQuizModel
    {
        /// <summary>
        /// Indicates the required number of questions in the quiz. The number may not exceed the number of questions for this topic.
        /// </summary>
        public int NumberOfQuestions { get; set; }
        /// <summary>
        /// Indicates the required number of questions the user needs to answer correctly to pass the test. This number may not exceed the number of questions in this quiz.
        /// </summary>
        public int PassThreshold { get; set; }
        /// <summary>
        /// Indicates whether the user should be prompted to complete a quiz before he/she can set the status of a topic on the learning plan to completed
        /// </summary>
        public bool Required { get; set; }
    }
}
