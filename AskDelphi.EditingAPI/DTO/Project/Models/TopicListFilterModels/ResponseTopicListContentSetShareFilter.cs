namespace AskDelphi.EditingAPI.DTO.Project.Models.TopicListFilterModels
{
    /// <summary>
    /// Contains information about content set, used to narrow down topics imported as part of content set sharing
    /// </summary>
    public class ResponseTopicListContentSetShareFilter
    {
        /// <summary>
        /// Unique id of content set share
        /// </summary>
        public Guid ShareId { get; set; }

        /// <summary>
        /// Title of the content set
        /// </summary>
        public string ContentSetTitle { get; set; }
        /// <summary>
        /// Title of the content set share
        /// </summary>
        public string ShareTitle { get; set; }
    }
}
