namespace AskDelphi.EditingAPI.DTO.ExternalSourceTopic.Models
{
    /// <summary>
    /// Contains status of each topic
    /// </summary>
    public class ResponseExternalSourceTopicRelationEntryResult
    {
        /// <summary>
        /// External source topic Id
        /// </summary>
        public Guid TopicId { get; set; }
        /// <summary>
        /// Title of the topic
        /// </summary>
        public string TopicTitle { get; set; }
        /// <summary>
        /// Indicates if topic is created
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Error message in case of topic creation failure
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
