namespace AskDelphi.EditingAPI.DTO.Topic.Models
{
    /// <summary>
    /// Response object containing information about the topic version
    /// </summary>
    public class ResponseTopicVersion
    {
        /// <summary>
        /// Major version
        /// </summary>
        public int MajorVersion { get; set; }
        /// <summary>
        /// Minor version
        /// </summary>
        public int MinorVersion { get; set; }
    }
}
