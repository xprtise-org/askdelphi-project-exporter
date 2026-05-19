namespace AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Models
{
    /// <summary>
    /// Contains tab content information
    /// </summary>
    public class RequestHomepageTabContentUpdateModel
    {
        /// <summary>
        /// Indicates the selected tab layout name (1-column, 2-columns-25-75 etc)
        /// </summary>
        public string SelectedTabLayout { get; set; }

        /// <summary>
        /// Collection of columns, defined for this homepage tab
        /// </summary>
        public IEnumerable<RequestHomepageTabContentColumnUpdateModel> Columns { get; set; }
    }
}
