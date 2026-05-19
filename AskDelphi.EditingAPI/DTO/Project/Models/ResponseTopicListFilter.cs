using AskDelphi.EditingAPI.DTO.Project.Models.TopicListFilterModels;

namespace AskDelphi.EditingAPI.DTO.Project.Models
{
    /// <summary>
    /// Contains filters used to narrow down topic list results
    /// </summary>
    public class ResponseTopicListFilter
    {
        /// <summary>
        /// Contains information about publications, which can be used to filter out topics only published to specified publications
        /// </summary>
        public IEnumerable<ResponseTopicListPublicationFilter> Publications { get; set; }

        /// <summary>
        /// Contains information about topic type groups, which can be used to filter out topics belonging to specified topic type groups
        /// </summary>
        public IEnumerable<ResponseTopicListTopicTypeGroupFilter> TopicTypeGroups { get; set; }

        /// <summary>
        /// Distinct list of all topic types for the content design
        /// </summary>
        public IEnumerable<ResponseTopicListTopicTypeFilter> TopicTypes { get; set; }

        /// <summary>
        /// Indicates if topic type group filtering should be enabled.
        /// Populated from project settings
        /// </summary>
        public bool EnableTopicTypeGroupFilter { get; set; }

        /// <summary>
        /// Indicates if publication filter should be enabled.
        /// Populated from project settings
        /// </summary>
        public bool EnabledPublicationFilter { get; set; }

        /// <summary>
        /// Indicates if content set shared topics should be excluded from the topic list. 
        /// When set to true, will disable filtering by content set share.
        /// Populated from project settings.
        /// </summary>
        public bool ExcludeSharedContent { get; set; }

        /// <summary>
        /// Hierarchy filters used to filter topics tagged to specific hierarchy nodes.
        /// Populated from RBAC hierarchy and any hierarchy set in topic filter hierarchies in project settings.
        /// If RBAC hierarchy is defined, always places the RBAC hierarchy first in the hierarchy list with name (Role Based Access Control).
        /// </summary>
        public IEnumerable<ResponseTopicListHierarchyFilter> Hierarchies { get; set; }

        /// <summary>
        /// Used to narrow down topics imported as part of content set sharing
        /// </summary>
        public IEnumerable<ResponseTopicListContentSetShareFilter> ContentSetShares { get; set; }
    }
}
