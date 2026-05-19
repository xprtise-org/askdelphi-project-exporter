namespace AskDelphi.JSONExport.Output
{
    public class CollectionModel : IModelWithBasicData, IModelWithThumbnail, IModelWithKeyVisual, IModelWithRelatedContent
    {
        /// <summary>
        /// Returns the type of this object.
        /// </summary>
        public string Type => GetType().Name;
        /// <summary>
        /// The URL that can be used by an end-user to access the contents of this Collection in the context of the full publication.
        /// </summary>
        public string? URL { get; set; }
        /// <summary>
        /// A unique identifier for this content. Will remain constant over multiple exports.
        /// </summary>
        public string? Guid { get; set; }
        /// <summary>
        /// The title of the information Collection.
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// If set, a short plain-text description of the Collection.
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
        /// List of items in the collection
        /// </summary>
        public List<CollectionItemModel> Items { get; set; } = [];

        /// <summary>
        /// Content that's referred to from this topic.
        /// </summary>
        public List<RelatedContent> RelatedContent { get; set; } = [];

        public class CollectionItemModel
        {
            /// <summary>
            /// The title for this collection item.
            /// </summary>
            public string? Title { get; set; }
            /// <summary>
            /// The target of this collection item.
            /// </summary>
            public CollectionItemTarget? Target { get; set; }
            /// <summary>
            /// Rich-text description of this item.
            /// </summary>
            public string? Body { get; set; }
            /// <summary>
            /// Button label for the item.
            /// </summary> 
            public string? ButtonLabel { get; set; }
            /// <summary>
            /// Path to the media file for this item.
            /// </summary>  
            public string? MediaFile { get; set; }
        }

        public class CollectionItemTarget
        {
            /// <summary>
            /// Guid for the target topic.
            /// </summary>
            public Guid TopicGuid { get; set; }
            /// <summary>
            /// File that the target topic can be read from.
            /// </summary>
            public string? Filename { get; set; }
        }
    }
}
