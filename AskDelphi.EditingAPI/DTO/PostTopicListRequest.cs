using KeyValuePair = AskDelphi.EditingAPI.DTO.Shared.KeyValuePair;

namespace AskDelphi.EditingAPI.DTO
{
    /// <summary>
    /// Request options used when retrieving the topic list. Can be used to manipulate the returned set of content.
    /// </summary>
    public class PostTopicListRequest
    {
        /// <summary>
        /// If specified and non-empty the result will contain only objects that match the query.
        /// </summary>
        /// <remarks>
        /// <para>A topic matches when the query is part of the title or if the query matches (part of) the topic's unique identifier.</para>
        /// </remarks>
        public string Query { get; set; }

        /// <summary>
        /// If specified and non-empty limits the topic types that can be returned.
        /// </summary>
        /// <remarks>
        /// <para>Only topics with a topic type id (in the content design) that's in the list will be returned, nothing else.</para>
        /// </remarks>
        public Guid[] TopicTypes { get; set; }

        /// <summary>
        /// If specified and non-empty limits the namespaces of the returned topics.
        /// </summary>
        /// <remarks>
        /// <para>Only topics that have the specified namespace will be returned, regardless of their topic type.</para>
        /// </remarks>
        public string[] Namespaces { get; set; }

        /// <summary>
        /// If specified and non-empty (where empty is also Guid.Empty) returns only topics that are part of that topic type group.
        /// </summary>
        /// <remarks>
        /// Only topics that are in the topic group
        /// </remarks>
        public Guid? TopicTypeGroupId { get; set; }

        /// <summary>
        /// When specified and true, will return only topics editable under the specified ACL.
        /// </summary>
        public bool? OnlyEditable { get; set; }

        /// <summary>
        /// Field to order by.
        /// </summary>
        /// <remarks>
        /// <para>One of: topictype, title, status, lastModificationDate or indexedVersion</para>
        /// </remarks>
        public string OrderBy { get; set; }

        /// <summary>
        /// Indicates if sorting is in ascending order, null indicates true by default, false sorts in descending order
        /// </summary>
        public bool? IsSortAsc { get; set; }

        /// <summary>
        /// If set filters topics published to specified publications guids
        /// </summary>
        public Guid[] PublicationGuids { get; set; }

        /// <summary>
        /// Indicates if only deleted topics should be returned, null indicates false by default
        /// </summary>
        public bool? OnlyDeleted { get; set; }

        /// <summary>
        /// Indicates if shared topics should be excluded from result, null indicates false by default
        /// </summary>
        public bool? ExcludeSharedContent { get; set; }

        /// <summary>
        /// If set will returned topics part of content set shares with specified guids
        /// </summary>
        public Guid[] ContentSetShareGuids { get; set; }

        /// <summary>
        /// Filter results to only topics tagged with any one of these hierarchy nodes, identified by their unique ID in the hierarchy.
        /// </summary>
        public string[] HierarchyNodeIds { get; set; }

        /// <summary>
        /// Page number, where the first page is 1.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Number of items to preferably return per page.
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Indicates wether only topics that are checkoued out by current user should be returned
        /// </summary>
        public bool CurrentlyCheckedOutByMe { get; set; }
        /// <summary>
        /// Filters result to include topics that are checked out by others onle
        /// </summary>
        public bool CurrentlyCheckedOutByOthers { get; set; }

        /// <summary>
        /// When specified will be used to filter topics only tagged to specified hierarchy id (key) and node id (value), only used for quering topics tagged to hierarchy node
        /// </summary>
        public KeyValuePair TaggedToNode { get; set; }
    }
}
