using AskDelphi.EditingAPI.DTO.Tenant.Models;

namespace AskDelphi.EditingAPI.DTO
{
    /// <summary>
    /// Contains tenant identifier
    /// </summary>
    public class GetTenantResponse
    {
        /// <summary>
        /// Contains information that uniquely identifies a tenant
        /// </summary>
        public ResponseTenantIdentifier TenantIdentifier { get; set; }


    }
}
