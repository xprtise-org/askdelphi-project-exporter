namespace AskDelphi.EditingAPI.DTO.Project.Models.TopicListFilterModels
{
    /// <summary>
    /// Contains information about topic type, used to filter topic list to specified topic type
    /// </summary>
    public class ResponseTopicListTopicTypeFilter
    {
        /// <summary>
        /// Unique id of the topic type
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Display name of the topic type
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Topic type namespace
        /// </summary>
        public string Namespace { get; set; }
    }
}
