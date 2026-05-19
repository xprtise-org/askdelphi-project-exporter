namespace AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Requests
{
    public class PostCheckInHomepageTopicRequest
    {
        /// <summary>
        /// When specified will check-in specified topic version
        /// </summary>
        public Guid? TopicVersionId { get; set; }
    }
}
