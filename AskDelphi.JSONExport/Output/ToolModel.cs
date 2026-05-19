namespace AskDelphi.JSONExport.Output
{
    public class ToolModel : IModelWithBasicData, IModelWithThumbnail, IModelWithKeyVisual, IModelWithRelatedContent
    {
        /// <summary>
        /// Returns the type of this object.
        /// </summary>
        public string Type => GetType().Name;
        /// <summary>
        /// The URL that can be used by an end-user to access the contents of this Nugget in the context of the full publication.
        /// </summary>
        public string? URL { get; set; }
        /// <summary>
        /// A unique identifier for this content. Will remain constant over multiple exports.
        /// </summary>
        public string? Guid { get; set; }
        /// <summary>
        /// The title of the information nugget.
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// If set, a short plain-text description of the nugget.
        /// </summary>
        public string? ShortDescription { get; set; }
        /// <summary>
        /// If set, contains a key visual for the topic that can be used for various purposes.
        /// </summary>
        public string? KeyVisualFile { get; set; }
        /// <summary>
        /// Optional thumbnail for this topic.
        /// </summary>
        public string? ThumbnailFile { get; set; }
        /// <summary>
        /// A list of all hierarchy nodes that the content is tagged to, can be used to tag imported content.
        /// </summary>
        public List<string>? Tags { get; set; }
        /// <summary>
        /// Hash of the serialized content, without this hash.
        /// </summary>
        public string? Hash { get; set; }
        /// <summary>
        /// Tool introduction.
        /// </summary>
        public string? Introduction { get; set; }
        /// <summary>
        /// Tool details.
        /// </summary>
        public string? Details { get; set; }
        /// <summary>
        /// Content that's referred to from this topic.
        /// </summary>
        public List<RelatedContent> RelatedContent { get; set; } = [];
    }
}
