namespace AskDelphi.EditingAPI.DTO.Project.Models
{
    /// <summary>
    /// Contains information about publication, used when selecting a publication to publish a topic to
    /// </summary>
    public class ResponseTopicPublicationOptionModel
    {
        /// <summary>
        /// Publication id
        /// </summary>
        public Guid PublicationId { get; set; }
        /// <summary>
        /// Publication name
        /// </summary>
        public string PublicationName { get; set; }
        /// <summary>
        /// Indicates whether publication configuration is valid
        /// </summary>
        public bool HasValidConfiguration { get; set; }
    }
}
