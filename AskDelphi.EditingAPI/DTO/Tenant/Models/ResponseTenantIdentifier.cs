namespace AskDelphi.EditingAPI.DTO.Tenant.Models
{
    /// <summary>
    /// Contains informatin that uniquely identifies a tenant
    /// </summary>
    public class ResponseTenantIdentifier
    {
        /// <summary>
        /// Unique tenant id
        /// </summary>
        public Guid TenantGuid { get; set; }
        /// <summary>
        /// Tenant title
        /// </summary>
        public string Title { get; set; }
    }
}
