namespace AskDelphi.EditingAPI.DTO.Editors.Label
{
    /// <summary>
    /// Configuration for label editor
    /// </summary>
    public class LabelEditorConfiguration
    {
        /// <summary>
        /// Indicates if label is hidden by default, (For example when dynamic accordion is built this is useful to get the title of the accordion without showing duplicate read-only label inside accordion body)
        /// </summary>
        public bool Hidden { get; set; }
    }
}
