namespace AskDelphi.EditingAPI.DTO.Editors.Menu
{
    /// <summary>
    /// Represents a grouped menu items
    /// </summary>
    public class MenuGroup
    {
        /// <summary>
        /// Group name for the menu items
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Menu items of this group, targeting supported topics
        /// </summary>
        public List<MenuGroupTarget> Items { get; set; } = [];
    }
}
