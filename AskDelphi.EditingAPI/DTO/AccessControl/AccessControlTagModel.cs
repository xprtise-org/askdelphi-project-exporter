namespace AskDelphi.EditingAPI.DTO.AccessControl
{
    /// <summary>
    /// Contains information about tags, used to identify user access to topics based on topics tags
    /// </summary>
    public class AccessControlTagModel
    {
        /// <summary>
        /// Hierarchy topic id
        /// </summary>
        public Guid HierarchyTopicId { get; set; }
        /// <summary>
        /// Hierarchy node ids
        /// </summary>
        public string HierarchyNodeId { get; set; }
    }
}
