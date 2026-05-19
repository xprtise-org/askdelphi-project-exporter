namespace AskDelphi.EditingAPI.DTO.Shared.Models
{
    /// <summary>
    /// Contains a model of a single rule within the content set definition
    /// </summary>
    public class ResponseContentSetRuleModel
    {
        /// <summary>
        /// Unique id of the rule
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// Order of the rule
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// Type of the rule
        /// </summary>
        public ContentSetRuleType ContentSetRuleType { get; set; }
        /// <summary>
        /// Unique id of the optional hierarchy topic for this rule
        /// </summary>
        public Guid? HierarchyTopicGuid { get; set; }
        /// <summary>
        /// Collection of selected hierarchy nodes for this rule
        /// </summary>
        public List<string> SelectedNodes { get; set; }
        /// <summary>
        /// Collection of applicable topic ids for this rule
        /// </summary>
        public List<ResponseTopicDescriptor> Topics { get; set; }
        /// <summary>
        /// Collection of topic type ids for this rule
        /// </summary>
        public List<Guid> TopicTypeIDs { get; set; }
    }
}
