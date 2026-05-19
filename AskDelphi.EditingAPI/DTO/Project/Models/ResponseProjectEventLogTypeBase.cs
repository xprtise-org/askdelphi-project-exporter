namespace AskDelphi.EditingAPI.DTO.Project.Models
{
    /// <summary>
    /// Base class for project event log classes
    /// </summary>
    public class ResponseProjectEventLogTypeBase
    {
        /// <summary>
        /// Full name of user performing the action
        /// </summary>
        public string ActingUser { get; set; }
    }
}
