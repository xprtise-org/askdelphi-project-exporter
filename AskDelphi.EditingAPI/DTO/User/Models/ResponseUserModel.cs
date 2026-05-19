namespace AskDelphi.EditingAPI.DTO.User.Models
{
    /// <summary>
    /// Contains information about the user
    /// </summary>
    public class ResponseUserModel
    {
        /// <summary>
        /// User Guid
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string UserName { get; set; }
    }
}
