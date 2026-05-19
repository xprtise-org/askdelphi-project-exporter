namespace AskDelphi.EditingAPI.DTO.Topic.Requests
{
    /// <summary>
    /// Request object containing two topic versions that should be compared
    /// </summary>
    public class PostTopicVersionComparisonRequest
    {
        /// <summary>
        /// Version 1 details
        /// </summary>
        public Guid Version1Guid { get; set; }
        /// <summary>
        /// Version 2 details
        /// </summary>
        public Guid Version2Guid { get; set; }
    }
}
