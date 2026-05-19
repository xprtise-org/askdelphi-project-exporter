namespace AskDelphi.EditingAPI.DTO.TopicLearning.Models
{
    public class RequestTopicLearningQuizQuestion
    {
        /// <summary>
        /// Indicates whether a single or multiple correct answers are available for this question
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Question title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Question body html
        /// </summary>
        public string BodyHTML { get; set; }
        /// <summary>
        /// Question more information html
        /// </summary>
        public string MoreInfoHTML { get; set; }
        /// <summary>
        /// Collection of available answers for this question
        /// </summary>
        public IEnumerable<RequestTopicLearningQuizAnswer> Answers { get; set; }
        /// <summary>
        /// The order of the question
        /// </summary>
        public int Order { get; set; }
    }
}
