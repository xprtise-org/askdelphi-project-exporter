namespace AskDelphi.EditingAPI.DTO.AccessControl
{
    /// <summary>
    /// Contains information about access control based on claims and coresponding role
    /// </summary>
    public class AccessControlModel
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
        public RoleDefinition RoleDefinition { get; set; }
        /// <summary>
        /// Restrictions used to identify applicable access control
        /// </summary>
        public AccessControlRestriction[] Restrictions { get; set; }
    }
}
