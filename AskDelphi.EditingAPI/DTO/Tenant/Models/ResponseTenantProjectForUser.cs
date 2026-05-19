namespace AskDelphi.EditingAPI.DTO.Tenant.Models
{
    /// <summary>
    /// Response object containing information about tenant projects that the user has access to
    /// </summary>
    public class ResponseTenantProjectForUser
    {
        /// <summary>
        /// Unique id of the project
        /// </summary>
        public Guid ProjectId { get; set; }
        /// <summary>
        /// Project title/name
        /// </summary>
        public string ProjectTitle { get; set; }
        /// <summary>
        /// Project logo sas uri
        /// </summary>
        public string LogoSasUri { get; set; }

        /// <summary>
        /// A list of acl entries, applicable to the user to this project
        /// </summary>
        public IEnumerable<ResponseTenantProjectForUserAcl> Acls { get; set; }
    }
}
