namespace AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Responses
{
    /// <summary>
    /// Response object, containing indetifier information of the updated tab
    /// </summary>
    public class PutUpdateHomepageTopicTabResponse
    {
        /// <summary>
        /// Indicates unique id of the tab
        /// </summary>
        public Guid TabId { get; set; }

        /// <summary>
        /// Indicates the title of the tab
        /// </summary>
        public string Title { get; set; }
    }
}
