using AskDelphi.EditingAPI.DTO.Tenant.Models;

namespace AskDelphi.EditingAPI.DTO.Tenant.Responses
{
    /// <summary>
    /// Response object containg all projects that the user can access for specified tenant
    /// </summary>
    public class GetTenantProjectsForUserResponse
    {
        /// <summary>
        /// Project information
        /// </summary>
        public IEnumerable<ResponseTenantProjectForUser> Data { get; set; }


    }
}
