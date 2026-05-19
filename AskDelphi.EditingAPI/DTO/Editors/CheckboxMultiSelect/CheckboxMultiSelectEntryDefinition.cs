namespace AskDelphi.EditingAPI.DTO.Editors.CheckboxMultiSelect
{
    /// <summary>
    /// Forms part of the checkbox multi select configuration, contains information about a single checkbox
    /// </summary>
    public class CheckboxMultiSelectEntryDefinition
    {
        /// <summary>
        /// The entry id represented by the checkbox
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Checkbox label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Additional description of the checkbox
        /// </summary>
        public string DescriptionHTML { get; set; }
    }
}
