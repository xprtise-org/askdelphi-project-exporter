namespace AskDelphi.EditingAPI.DTO.TopicLearning.Requests
{
    /// <summary>
    /// Update request for topic learning description
    /// </summary>
    public class PutUpdateTopicLearningDescriptionRequest
    {
        /// <summary>
        /// The description of topic learning in html format
        /// </summary>
        public string DescriptionHTML { get; set; }
    }
}
