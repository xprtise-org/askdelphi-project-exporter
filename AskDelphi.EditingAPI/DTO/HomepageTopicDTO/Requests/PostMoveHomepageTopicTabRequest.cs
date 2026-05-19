namespace AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Requests
{
    /// <summary>
    /// Contains information about the movement request
    /// </summary>
    public class PostMoveHomepageTopicTabRequest
    {
        /// <summary>
        /// Target index that the tab is moved to
        /// </summary>
        public int TargetIndex { get; set; }
    }
}
