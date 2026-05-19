namespace AskDelphi.EditingAPI.DTO.Editors
{
    /// <summary>
    /// Contents and structure of the topic type editor for this instance of the topic
    /// </summary>
    public class TopicTypeEditorDefinition
    {
        /// <summary>
        /// Grouped data
        /// </summary>
        public TopicPartGroup[] Groups { get; set; }
        /// <summary>
        /// Topic namespace
        /// </summary>
        public string Namespace { get; set; }
        /// <summary>
        /// Name of the topic type
        /// </summary>
        public string TopicTypeName { get; set; }

        /// <summary>
        /// Commar delimited collection of stages for topic version
        /// </summary>
        public string Stages { get; set; }

        /// <summary>
        /// Indicates the major and minor version of this topic
        /// </summary>
        public string VersionNo { get; set; }
    }
}
