namespace AskDelphi.EditingAPI.DTO.Editors.Menu
{
    /// <summary>
    /// Menu item targeted topic
    /// </summary>
    public class MenuGroupTarget
    {
        /// <summary>
        /// Menu item title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Selected topic guid
        /// </summary>
        public string TargetId { get; set; }
        /// <summary>
        /// Selected topic title
        /// </summary>
        public string TargetName { get; set; }

    }
}
