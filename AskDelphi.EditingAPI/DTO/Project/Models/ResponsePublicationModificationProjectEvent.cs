namespace AskDelphi.EditingAPI.DTO.Project.Models
{
    /// <summary>
    /// Event for logging publication CRUD operations
    /// </summary>
    public class ResponsePublicationModificationProjectEvent : ResponseProjectEventLogTypeBase
    {
        /// <summary>
        /// Id of the publication
        /// </summary>
        public Guid PublicationGuid { get; set; }
        /// <summary>
        /// Publication title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The status of the publication
        /// </summary>
        public ProjectEventLogPublicationStatus Status { get; set; }
    }

    public enum ProjectEventLogPublicationStatus
    {
        /// <summary></summary>
        Created,
        /// <summary></summary>
        Updated,
        /// <summary></summary>
        Deleted
    }
}
