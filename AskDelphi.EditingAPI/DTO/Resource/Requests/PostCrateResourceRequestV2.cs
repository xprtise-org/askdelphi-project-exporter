using Microsoft.AspNetCore.Http;

namespace AskDelphi.EditingAPI.DTO.Resource.Requests
{
    /// <summary>
    /// Request object containing upload file and target publication guid (optional)
    /// </summary>
    public class PostCreateResourceRequestV2
    {
        /// <summary>
        /// Publication ids, when specified will publish newly created resource topic to target publications
        /// </summary>
        public IEnumerable<Guid> PublicationIds { get; set; }
        /// <summary>
        /// File, containing the resource
        /// </summary>
        public IFormFile File { get; set; }
    }
}
