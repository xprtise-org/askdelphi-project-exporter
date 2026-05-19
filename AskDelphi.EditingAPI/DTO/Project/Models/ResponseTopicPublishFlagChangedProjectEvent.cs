namespace AskDelphi.EditingAPI.DTO.Project.Models
{
    /// <summary>
    /// Event used for logging changes to "do not publish" topic flag
    /// </summary>
    public class ResponseTopicPublishFlagChangedProjectEvent : ResponseProjectEventLogTypeBase
    {
        /// <summary>
        /// Topic id
        /// </summary>
        public Guid TopicGuid { get; set; }

        /// <summary>
        /// Topic title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The value of the "do not publish" flag
        /// </summary>
        public bool DoNotPublish { get; set; }
    }
}
