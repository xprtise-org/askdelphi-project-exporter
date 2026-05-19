namespace AskDelphi.EditingAPI.DTO.Topic.Requests
{
    /// <summary>
    /// Contains information required to update hierarchy node description
    /// </summary>
    public class PutUpdateHierarchyNodeDescriptionRequest
    {
        /// <summary>
        /// Target node id
        /// </summary>
        public string HierarchyNodeId { get; set; }
        /// <summary>
        /// New description of the node
        /// </summary>
        public string DescriptionHTML { get; set; }
    }
}
