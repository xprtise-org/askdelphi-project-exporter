namespace AskDelphi.EditingAPI.DTO.ExternalSourceTopic
{
    /// <summary>
    /// Contains information about required resource
    /// </summary>
    public class PostDownloadExternalAdapterResourceRequest
    {
        /// <summary>
        /// External adapter id
        /// </summary>
        public string AdapterId { get; set; }

        /// <summary>
        /// External topic id/resource id
        /// </summary>
        public string TopicId { get; set; }
    }
}
