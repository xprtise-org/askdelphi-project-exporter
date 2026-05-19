using Microsoft.AspNetCore.Http;

namespace AskDelphi.EditingAPI.DTO.Resource.Requests
{
    /// <summary>
    /// Request object containing upload file and target publication guid (optional)
    /// </summary>
    public class PostCreateResourceRequest
    {
        /// <summary>
        /// Publication guid, when specified will publish newly created resource topic to target publication
        /// </summary>
        public Guid? PublicationId { get; set; }
        /// <summary>
        /// File, containing the resource
        /// </summary>
        public IFormFile File { get; set; }
    }
}
