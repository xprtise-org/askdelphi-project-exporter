namespace AskDelphi.EditingAPI.DTO.Editors.ImageMap
{
    /// <summary>
    /// Configuration for image map editor
    /// </summary>
    public class ImageMapConfiguration
    {
        /// <summary>
        /// Indicates whether topics are used as targets, or in the case of expandable content items 
        /// </summary>
        public bool UseTopicsAsTargets { get; set; }
        /// <summary>
        /// Optional id of the editor to which the image map editor must subscribe for changes, in order to obtain latest items/targets for areas
        /// </summary>
        public string TargetEditorId { get; set; }
    }
}
