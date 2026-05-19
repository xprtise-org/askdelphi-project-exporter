namespace AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Requests
{
    public class PostPublishHomepageTopicRequest
    {
        /// <summary>
        /// Target publication ids, for which topic should be published
        /// </summary>
        public Guid[] PublicationIds { get; set; }
    }
}
