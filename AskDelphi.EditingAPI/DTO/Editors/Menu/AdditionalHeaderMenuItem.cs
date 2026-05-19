namespace AskDelphi.EditingAPI.DTO.Editors.Menu
{
    /// <summary>
    /// Represents the menu item in the nav header
    /// </summary>
    public class AdditionalHeaderMenuItem
    {
        /// <summary>
        /// Menu item icon 
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Menu item targeted topic
        /// </summary>
        public MenuGroupTarget Target { get; set; }
    }
}
