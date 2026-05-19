namespace AskDelphi.EditingAPI.DTO.Shared.Models
{
    /// <summary>
    /// Contains definition of a single content set rule
    /// </summary>
    public class RequestContentSetRuleModel
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
        public List<Guid> TopicGuids { get; set; }
        /// <summary>
        /// Collection of topic type ids for this rule
        /// </summary>
        public List<Guid> TopicTypeIDs { get; set; }
    }

    public enum ContentSetRuleType
    {
        /// <summary>Indicates that all topics should be included in content set calculation</summary>
        IncludeAll,
        /// <summary>Indicates that only related content should be included in content set calculation</summary>
        IncludeRelatedContent,
        /// <summary>Indicates that only selected/specific topics should be included in content set calculation</summary>
        IncludeSpecificTopics,
        /// <summary>Indicates that only tagged topics should be included in content set calculation</summary>
        IncludeTaggedContent,
        /// <summary>Indicates that only selected/specific topic types should be included in content set calculation</summary>
        IncludeTopicsOfType,
        /// <summary>Indicates that only tagged topics should be excluded in content set calculation</summary>
        ExcludeTaggedContent,
        /// <summary>Indicates that only specific topics should be excluded in content set calculation</summary>
        ExcludeSpecificTopics,
        /// <summary>Indicates that only specific topic types should be excluded in content set calculation</summary>
        ExcludeTopicsOfType
    }
}
