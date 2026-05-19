namespace AskDelphi.EditingAPI.DTO.Resource.Requests
{
    /// <summary>
    /// Create new External Url topic request
    /// </summary>
    public class PostExternalUrlNewRequestV2
    {
        /// <summary>
        /// Target uri
        /// </summary>
        public string TargetUri { get; set; }
        /// <summary>
        /// PublicationIds (optional), when set the new topic will be published upon creation.
        /// </summary>
        public IEnumerable<Guid> PublicationIds { get; set; }
    }
}
