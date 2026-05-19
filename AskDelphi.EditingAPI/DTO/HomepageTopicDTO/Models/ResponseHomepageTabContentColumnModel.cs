namespace AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Models
{
    /// <summary>
    /// Contains group information for a column
    /// </summary>
    public class ResponseHomepageTabContentColumnModel
    {
        /// <summary>
        /// Unique id of the tab column
        /// </summary>
        public Guid? ColumnId { get; set; }

        /// <summary>
        /// Collection of groups, defined for this column
        /// </summary>
        public IEnumerable<ResponseHomepageTabContentGroupModel> Groups { get; set; }
    }
}
