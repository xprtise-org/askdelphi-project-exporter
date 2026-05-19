namespace AskDelphi.EditingAPI.DTO.Project.Models
{
    /// <summary>
    /// Event for logging full publication 
    /// </summary>
    public class ResponseFullPublicationStartedProjectEvent : ResponseProjectEventLogTypeBase
    {
        /// <summary>
        /// Id of the publication
        /// </summary>
        public Guid PublicationGuid { get; set; }
        /// <summary>
        /// Publication title
        /// </summary>
        public string Title { get; set; }
    }
}
