namespace AskDelphi.EditingAPI.DTO.Editors
{
    public class TopicPartFieldEditor
    {
        public string DefaultLabel { get; set; }
        public string DescriptionHTML { get; set; }
        public string EditorFieldId { get; set; }
        public bool IsRequired { get; set; }
        public EditorType Type { get; set; }
        public TypeDependentConfiguration TypeDependentConfigurationData { get; set; }
        public EditorValue Value { get; set; }
    }
}