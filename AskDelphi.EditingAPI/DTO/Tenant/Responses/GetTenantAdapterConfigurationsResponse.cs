using AskDelphi.EditingAPI.DTO.Tenant.Models;

namespace AskDelphi.EditingAPI.DTO.Tenant.Responses
{
    /// <summary>
    /// Tenant adapter configuration response containing adapter configurations for external source topics
    /// </summary>
    public class GetTenantAdapterConfigurationsResponse
    {
        /// <summary>
        /// Adapter configuration collection
        /// </summary>
        public IEnumerable<ResponseAdapterConfiguration> Data { get; set; }


    }
}
