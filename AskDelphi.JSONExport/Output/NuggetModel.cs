namespace AskDelphi.JSONExport.Output
{
    public class NuggetModel : IModelWithBasicData, IModelWithThumbnail, IModelWithKeyVisual, IModelWithRelatedContent
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
        /// The full description of the nugget, a basic explanation of the step.
        /// </summary>
        public string? FullDescription { get; set; }
        /// <summary>
        /// A list of all hierarchy nodes that the content is tagged to, can be used to tag imported content.
        /// </summary>
        public List<string>? Tags { get; set; }
        /// <summary>
        /// The list of steps that needs to be executed sequentially to complete this task.
        /// </summary>
        public List<NuggetStep>? Steps { get; set; }
        /// <summary>
        /// Filename of the downloaded instruction video.
        /// </summary>
        public string? InstructionVideoFilename { get; set; }
        /// <summary>
        /// Filename of the primary tip image for this nugget.
        /// </summary>
        public string? TipImageFilename { get; set; }
        /// <summary>
        /// Description of the nugget tip.
        /// </summary>
        public string? TipText { get; set; }
        /// <summary>
        /// This hash is calculated over all contents of this JSON prior to calculatign the hash. When this hash changes, it's valid to assume the contents of the JSON have changed.
        /// </summary>
        public string? Hash { get; set; }

        /// <summary>
        /// If set, contains a key visual for the topic that can be used for various purposes.
        /// </summary>
        public string? KeyVisualFile { get; set; }
        /// <summary>
        /// Optional thumbnail for this topic.
        /// </summary>
        public string? ThumbnailFile { get; set; }
        /// <summary>
        /// Content that's referred to from this topic.
        /// </summary>
        public List<RelatedContent> RelatedContent { get; set; } = [];

        /// <summary>
        /// Single step in the process.
        /// </summary>
        public class NuggetStep
        {
            /// <summary>
            /// Instructions for this step.
            /// </summary>
            public string? Instructions { get; set; }
            /// <summary>
            /// Instructions for this step.
            /// </summary>
            public string? Text { get; set; }
            /// <summary>
            /// Image to be displayed alongside thiss step, whowing the actio the user should take.
            /// </summary>
            public string? ImageFilename { get; set; }
        }
    }
}
