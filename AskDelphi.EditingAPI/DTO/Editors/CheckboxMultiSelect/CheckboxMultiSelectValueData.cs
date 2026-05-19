namespace AskDelphi.EditingAPI.DTO.Editors.CheckboxMultiSelect
{
    /// <summary>
    /// Contains values of selected checkboxes
    /// </summary>
    public class CheckboxMultiSelectValueData
    {
        /// <summary>
        /// Selected values (ids), based on checked checkboxes
        /// </summary>
        public List<string> SelectedValues { get; set; }
    }
}
