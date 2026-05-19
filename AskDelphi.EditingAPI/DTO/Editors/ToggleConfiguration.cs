namespace AskDelphi.EditingAPI.DTO.Editors
{
    public class ToggleConfiguration
    {
        public string TrueLabel { get; set; }
        public string FalseLabel { get; set; }
        /// <summary>
        /// When value is true in the toggle value data, indicates editors with ids that should be hidden
        /// </summary>
        public string[] EditorIdsToHideOnTrue { get; set; }
        /// <summary>
        /// When value is false in the toggle value data, indicates editors with ids that should be hidden
        /// </summary>
        public string[] EditorIdsToHideOnFalse { get; set; }

        /// <summary>
        /// When value is true, hides the label
        /// </summary>
        public bool HideLabel { get; set; }
    }
}
