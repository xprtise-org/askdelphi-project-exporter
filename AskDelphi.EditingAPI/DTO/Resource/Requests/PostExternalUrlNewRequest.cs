namespace AskDelphi.EditingAPI.DTO.Resource.Requests
{
    /// <summary>
    /// Create new External Url topic request
    /// </summary>
    public class PostExternalUrlNewRequest
    {
        /// <summary>
        /// Target 
        /// </summary>
        public string TargetUri { get; set; }
        /// <summary>
        /// publicationId (optional), when set the new topic will be published upon creation.
        /// </summary>
        public string PublicationId { get; set; }
    }
}
