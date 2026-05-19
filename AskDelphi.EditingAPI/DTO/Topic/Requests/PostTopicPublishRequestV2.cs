namespace AskDelphi.EditingAPI.DTO.Topic.Requests
{
    /// <summary>
    /// Contains information about publication guids that need to be published
    /// </summary>
    public class PostTopicPublishRequestV2
    {
        /// <summary>
        /// Target publication ids, for which topic should be published
        /// </summary>
        public Guid[] PublicationIds { get; set; }
    }
}
