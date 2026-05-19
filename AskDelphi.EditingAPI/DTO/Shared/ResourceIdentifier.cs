namespace AskDelphi.EditingAPI.DTO.Shared
{
    public class ResourceIdentifier
    {
        /// <summary>
        /// The topic ID of the newly created resource topic.
        /// </summary>
        public Guid TopicGuid { get; set; }
        /// <summary>
        /// The title of the newly created resource topic.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The topic type key, indicating the type of topic that was created.
        /// </summary>
        public Guid TopicTypeKey { get; set; }
        /// <summary>
        /// The name of that topic type that wass created.
        /// </summary>
        public string TopicTypeName { get; set; }
        /// <summary>
        /// Topic namespace of the resource topic.
        /// </summary>
        public string TopicTypeNamespace { get; set; }
        /// <summary>
        /// A thumbnail image of the newly added topic.
        /// </summary>
        public string ThumbnailImageBase64 { get; set; }
    }
}
