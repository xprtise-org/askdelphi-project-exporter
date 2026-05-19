namespace AskDelphi.EditingAPI.DTO.Project.Models
{
    /// <summary>
    /// Object containing information about topic check in event
    /// </summary>
    public class ResponseTopicCheckedInProjectEvent : ResponseProjectEventLogTypeBase
    {
        /// <summary>
        /// Topic id
        /// </summary>
        public Guid TopicGuid { get; set; }

        /// <summary>
        /// Topic title
        /// </summary>
        public string Title { get; set; }
    }
}
