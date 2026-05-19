namespace AskDelphi.EditingAPI.DTO.Editors.ListEditor
{
    public class ListValueData
    {
        /// <summary>
        /// Optional property, indicates the unique id of the list item
        /// </summary>
        public string Id { get; set; }
        public EditorValue[] Values { get; set; }
    }
}