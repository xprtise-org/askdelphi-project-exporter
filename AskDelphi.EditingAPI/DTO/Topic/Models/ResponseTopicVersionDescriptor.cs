namespace AskDelphi.EditingAPI.DTO.Topic.Models
{
    /// <summary>
    /// Contains descriptive information about a topic version
    /// </summary>
    public class ResponseTopicVersionDescriptor
    {
        /// <summary>
        /// Unique id of the topic version
        /// </summary>
        public Guid TopicVersionId { get; set; }
        /// <summary>
        /// Topic version title
        /// </summary>
        public string Title { get; set; }
        public string Stages { get; set; }
        /// <summary>
        /// Version no. of the parent from which this version is derived
        /// </summary>
        public string ParentVersionNo { get; set; }
    }
}
