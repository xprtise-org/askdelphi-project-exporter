namespace AskDelphi.EditingAPI.DTO.Tenant.Models
{
    /// <summary>
    /// External topic source adapter configuration
    /// </summary>
    public class ResponseAdapterConfiguration
    {
        /// <summary>
        /// External storage container name
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// External storage container SAS URI
        /// </summary>
        public string Url { get; set; }
    }
}
