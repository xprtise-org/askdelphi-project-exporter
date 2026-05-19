namespace AskDelphi.EditingAPI.DTO.TopicLearning.Models
{
    public class ResponseTopicLearningQuizAnswer
    {
        /// <summary>
        /// Answer html text
        /// </summary>
        public string AnswerHTML { get; set; }
        /// <summary>
        /// Indicates whether answer is correct
        /// </summary>
        public bool IsCorrect { get; set; }
        /// <summary>
        /// The order of the answer
        /// </summary>
        public int Order { get; set; }
    }
}
