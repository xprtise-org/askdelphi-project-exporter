namespace AskDelphi.EditingAPI.DTO.Editors.Menu
{
    /// <summary>
    /// Menu editor data
    /// </summary>
    public class MenuEditorData
    {
        /// <summary>
        /// Collection of grouped menu items
        /// </summary>
        public List<MenuGroup> MenuGroups { get; set; } = [];
        /// <summary>
        /// Collection of menu items for nav header
        /// </summary>
        public List<AdditionalHeaderMenuItem> AdditionalHeaderMenuItems { get; set; } = [];
    }
}
