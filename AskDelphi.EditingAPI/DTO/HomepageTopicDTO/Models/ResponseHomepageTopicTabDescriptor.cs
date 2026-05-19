namespace AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Models
{
    /// <summary>
    /// Contains description information about a homepage topic tab
    /// </summary>
    public class ResponseHomepageTopicTabDescriptor
    {
        /// <summary>
        /// Unique id of the tab
        /// </summary>
        public Guid TabId { get; set; }
        /// <summary>
        /// Indicates the id of the homepage topic for this tab.
        /// In case of homepage-tab (the first tab) this will be the same id as the homepage topic itself
        /// </summary>
        public Guid? HomepageTopicId { get; set; }

        /// <summary>
        /// Indicates the title of the homepage topic
        /// </summary>
        public string HomepageTopicTitle { get; set; }

        /// <summary>
        /// Indicates the title of this tab.
        /// In case of homepage-tab (the first tab) this will be the same title as the homepage topic title
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

        /// <summary>
        /// Indicates that target homepage is checked out by another user, and hence tab is readonly
        /// </summary>
        public bool IsReadonly { get; set; }

    }
}
