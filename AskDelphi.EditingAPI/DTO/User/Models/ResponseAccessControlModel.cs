namespace AskDelphi.EditingAPI.DTO.User.Models
{
    /// <summary>
    /// Contains information about access control based on claims and coresponding role
    /// </summary>
    public class ResponseAccessControlModel
    {
        /// <summary>
        /// Unique id of the access control
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Title of the model
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Description of the access control
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Id pointing to applicable role defintions for this access control
        /// </summary>
        public Guid? RoleDefinitionId { get; set; }
        /// <summary>
        /// Roles defining user access control
        /// </summary>
        public ResponseRoleDefinition RoleDefinition { get; set; }
    }
}
