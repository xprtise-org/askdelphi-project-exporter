namespace AskDelphi.EditingAPI.DTO.Editors
{
    public class CheckboxMultiSelectConfiguration
    {
        /// <summary>
        /// Editor's data definition
        /// </summary>
        public IEnumerable<CheckboxMultiSelectEntryDefinition> Options { get; set; }
    }

    public class CheckboxMultiSelectEntryDefinition
    {
        /// <summary>
        /// Checkbox's value
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Checkbox's display text
        /// </summary>
        public string Label { get; set; }
    }
}
