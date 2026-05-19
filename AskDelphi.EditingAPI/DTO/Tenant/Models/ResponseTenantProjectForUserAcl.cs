using AskDelphi.EditingAPI.DTO.AccessControl;

namespace AskDelphi.EditingAPI.DTO.Tenant.Models
{
    /// <summary>
    /// Object containing information about acl applicable to user for a specific tenant project
    /// </summary>
    public class ResponseTenantProjectForUserAcl
    {
        /// <summary>
        /// Id of the acl
        /// </summary>
        public Guid AclId { get; set; }

        /// <summary>
        /// Acl title/name
        /// </summary>
        public string AclTitle { get; set; }

        /// <summary>
        /// Title of the role for this ACL
        /// </summary>
        public string RoleTitle { get; set; }

        /// <summary>
        /// Unique identifier of the ACL's role
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// Roles defining user access control
        /// </summary>
        public RoleDefinition RoleDefinition { get; set; }
    }
}
