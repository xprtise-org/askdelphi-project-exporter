namespace AskDelphi.EditingAPI.DTO.Project.Models.TopicListFilterModels
{
    /// <summary>
    /// Contains information about hierarchy and its nodes, used to filter topic list, based on topics tagged to hierarchy nodes
    /// </summary>
    public class ResponseTopicListHierarchyFilter
    {
        /// <summary>
        /// Unique id of the hierarchy topic
        /// </summary>
        public Guid HierarchyId { get; set; }
        /// <summary>
        /// Hierarchy title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Hierarchy nodes
        /// </summary>
        public IEnumerable<ResponseTopicListHierarchyNodeFilter> Nodes { get; set; }
    }
}
