namespace AskDelphi.EditingAPI.DTO.Project.Models
{
    /// <summary>
    /// Represents a simple topic type descriptor
    /// </summary>
    public class ResponseTopicTypeDescriptor
    {
        /// <summary>
        /// Unique id of the topic type
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Display name of the topic type
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Namespace of the topic type
        /// </summary>
        public string Namespace { get; set; }
    }
}
