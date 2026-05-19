namespace AskDelphi.EditingAPI.DTO.AccessControl
{
    /// <summary>
    /// A single role model defined per project
    /// </summary>
    public class RoleModel
    {
        /// <summary>
        /// A collection of roles
        /// </summary>
        public RoleDefinition[] Roles { get; set; }

        /// <summary>
        /// Access control entries used to identify user's access control/roles based on claims and restrictions
        /// </summary>
        public AccessControlModel[] Entries { get; set; }
    }
}
