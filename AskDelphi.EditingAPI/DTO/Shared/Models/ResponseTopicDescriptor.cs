namespace AskDelphi.EditingAPI.DTO.Shared.Models
{
    /// <summary>
    /// Represents a simple topic descriptor
    /// </summary>
    public class ResponseTopicDescriptor
    {
        /// <summary>
        /// Unique id of the topic
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Title of the topic
        /// </summary>
        public string Title { get; set; }
    }
}
