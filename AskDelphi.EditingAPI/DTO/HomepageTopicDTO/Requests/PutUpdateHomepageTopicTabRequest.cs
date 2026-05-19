namespace AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Requests
{
    /// <summary>
    /// Request object containing information used to update a tab
    /// </summary>
    public class PutUpdateHomepageTopicTabRequest
    {
        /// <summary>
        /// Indicates the id of the homepage topic for this tab.
        /// </summary>
        public Guid? HomepageTopicId { get; set; }

        /// <summary>
        /// Indicates the title of this tab.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Indicates the custom icon for this tab
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Indicates the css class for this tab
        /// </summary>
        public string CssClass { get; set; }
    }
}
