namespace AskDelphi.EditingAPI.DTO.Shared
{
    /// <summary>
    /// Base information for a tag model
    /// </summary>
    public class ResponseTagModelBase
    {
        /// <summary>
        /// Unique id of the hierarchy topic
        /// </summary>
        public Guid HierarchyTopicId { get; set; }
        /// <summary>
        /// Title of the hierarchy topic
        /// </summary>
        public string HierarchyTopicTitle { get; set; }
        /// <summary>
        /// Unique id of the node
        /// </summary>
        public Guid HierarchyNodeId { get; set; }
        /// <summary>
        /// Title of the node
        /// </summary>
        public string HierarchyNodeTitle { get; set; }
        /// <summary>
        /// Calculated path to node based on parent nodes
        /// </summary>
        public string PathToNode { get; set; }
    }
}
