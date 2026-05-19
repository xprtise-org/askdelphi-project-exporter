namespace AskDelphi.EditingAPI.DTO.Project.Models.TopicListFilterModels
{
    /// <summary>
    /// Contains information about publications, used to filter topic list published to these publications
    /// </summary>
    public class ResponseTopicListPublicationFilter
    {
        /// <summary>
        /// Unique id of the publication
        /// </summary>
        public Guid PublicationId { get; set; }
        /// <summary>
        /// Name of the publication
        /// </summary>
        public string PublicationName { get; set; }
    }
}
