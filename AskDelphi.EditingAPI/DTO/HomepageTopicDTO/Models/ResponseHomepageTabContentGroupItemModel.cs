namespace AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Models
{
    /// <summary>
    /// Identifies a single group item with target topic and custom class names
    /// </summary>
    public class ResponseHomepageTabContentGroupItemModel
    {
        /// <summary>
        /// Unique id of the target topic for this item
        /// </summary>
        public Guid? TargetTopicId { get; set; }

        /// <summary>
        /// Indicates the title of the target topic
        /// </summary>
        public string TargetTopicTitle { get; set; }

        /// <summary>
        /// Indicates the title/lookup key of the target topic
        /// </summary>
        public string TargetTopicType { get; set; }

        /// <summary>
        /// Indicates the namespace of the target topic
        /// </summary>
        public string TargetTopicTypeNamespace { get; set; }

        /// <summary>
        /// Unique id of this item
        /// </summary>
        public Guid ItemId { get; set; }

        /// <summary>
        /// Custom class names, when set, will be applied to publication html
        /// </summary>
        public string CustomClassNames { get; set; }
    }
}
