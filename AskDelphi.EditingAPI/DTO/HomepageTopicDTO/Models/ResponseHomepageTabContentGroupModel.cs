namespace AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Models
{
    /// <summary>
    /// Contains configuration and details of a homepage tab group
    /// </summary>
    public class ResponseHomepageTabContentGroupModel
    {
        /// <summary>
        /// Unique id of the group
        /// </summary>
        public Guid GroupId { get; set; }

        /// <summary>
        /// Indicates the group type (fixed items, user items, statistics etc.)
        /// </summary>
        public string GroupType { get; set; }

        /// <summary>
        /// Custom label, when set will be displayed in the publication on top of the group
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Indicates the custom css, when set will be applied in the publication html
        /// </summary>
        public string CustomClassNames { get; set; }

        /// <summary>
        /// Indicates selected <seealso cref="ResponseHomepageTabContentGroupLayout.Name"/> for this group
        /// </summary>
        public string SelectedLayoutName { get; set; }

        /// <summary>
        /// For explode collections group types, indicates the grid layout (1x1 or 2x1 tiles)
        /// </summary>
        public string SelectedGridLayout { get; set; }

        /// <summary>
        /// For "Display row(s) with 'Show all' option" group type, indicates the "Number of initial rows to be rendered"
        /// For "Display all" group type, indicates the "Maximum number of rows to be rendered"
        /// </summary>
        public int NumberOfRows { get; set; }

        /// <summary>
        /// Gets or sets the menu items.
        /// </summary>
        public List<ResponseHomepageTabContentGroupItemModel> Items { get; set; }
    }
}
