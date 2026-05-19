namespace AskDelphi.EditingAPI.DTO.Editors.ImageMap
{
    /// <summary>
    /// Contains information that defines a drawn shape/area on the image map with a target to either a topic or an item
    /// </summary>
    public class ImageMapAreaValueData
    {
        /// <summary>
        /// Shape name/type e.g square, polygon etc
        /// </summary>
        public string Shape { get; set; }
        /// <summary>
        /// The coordinates of the shape on the image
        /// </summary>
        public string Coords { get; set; }
        /// <summary>
        /// Target topic id or target item id (in case of expandable content)
        /// </summary>
        public string TargetId { get; set; }
        /// <summary>
        /// Target topic title or target item title (in case of expandable content)
        /// </summary>
        public string TargetTitle { get; set; }
    }
}
