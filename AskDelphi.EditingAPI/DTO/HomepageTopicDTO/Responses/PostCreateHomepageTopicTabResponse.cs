namespace AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Responses
{
    /// <summary>
    /// Response object, containing newly created tab title and corresponding homepage topic id
    /// </summary>
    public class PostCreateHomepageTopicTabResponse
    {
        /// <summary>
        /// Indicates unique id of the tab
        /// </summary>
        public Guid TabId { get; set; }

        /// <summary>
        /// Indicates the title of the created tab
        /// </summary>
        public string Title { get; set; }
    }
}
