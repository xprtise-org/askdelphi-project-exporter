namespace AskDelphi.EditingAPI.DTO.Project.Models.TopicListFilterModels
{
    /// <summary>
    /// Contains information about hierarchy nodes, used to filter topics tagged to these nodes
    /// </summary>
    public class ResponseTopicListHierarchyNodeFilter
    {
        /// <summary>
        /// Unique id of the hierarchy node
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Title of the hierarchy node
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Child nodes
        /// </summary>
        public IEnumerable<ResponseTopicListHierarchyNodeFilter> Children { get; set; }
    }
}
