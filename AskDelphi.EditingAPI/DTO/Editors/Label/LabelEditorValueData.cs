namespace AskDelphi.EditingAPI.DTO.Editors.Label
{
    /// <summary>
    /// Value for label editor
    /// Label editor, is not actually an editor, but rather a read-only label with corresponding id of the object/entity used to get the label 
    /// </summary>
    public class LabelEditorValueData
    {
        /// <summary>
        /// Unique id that corresponds to label. Forexample, label can be a hierarchy title, hence the id will be the hierarchy guid.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The text displayed in the label
        /// </summary>
        public string Label { get; set; }
    }
}
