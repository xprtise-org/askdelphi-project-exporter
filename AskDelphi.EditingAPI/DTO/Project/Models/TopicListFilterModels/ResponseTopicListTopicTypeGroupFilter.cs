namespace AskDelphi.EditingAPI.DTO.Project.Models.TopicListFilterModels
{
    /// <summary>
    /// Contains information about topic type group, used to filter topic list to topics part of specified topic type group
    /// </summary>
    public class ResponseTopicListTopicTypeGroupFilter
    {
        /// <summary>
        /// Unique id of the topic type group
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Display name of the topic type group
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// All topic types that belong to this group
        /// </summary>
        public IEnumerable<Guid> TopicTypeIds { get; set; }
    }
}
