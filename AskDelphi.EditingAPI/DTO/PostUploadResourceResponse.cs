namespace AskDelphi.EditingAPI.DTO
{
    /// <summary>
    /// Upload resource response object
    /// </summary>
    public class PostUploadResourceResponse(Guid resourceId, string sha1, string fileName, string mimeType)
    {
        /// <summary>
        /// Resource unique id used to generate SAS URI from backend
        /// </summary>
        public Guid ResourceId { get; set; } = resourceId;
        /// <summary>
        /// SHA1 of resource stream
        /// </summary>
        public string ResourceSHA1 { get; set; } = sha1;
        /// <summary>
        /// File name with extension
        /// </summary>
        public string FileName { get; set; } = fileName;
        /// <summary>
        /// File mime-type
        /// </summary>
        public string MimeType { get; set; } = mimeType;
    }
}
