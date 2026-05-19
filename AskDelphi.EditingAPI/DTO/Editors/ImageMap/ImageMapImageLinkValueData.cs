namespace AskDelphi.EditingAPI.DTO.Editors.ImageMap
{
    /// <summary>
    /// Contains information
    /// </summary>
    public class ImageMapImageLinkValueData : SingleTopicChooserValueData
    {
        /// <summary>
        /// Indicates whether image link is existing. Legacy support
        /// </summary>
        public bool IsExisting { get; set; }

        /// <summary>
        /// Indicates the url to the image
        /// </summary>
        public string ImageUrl { get; set; }
    }
}
