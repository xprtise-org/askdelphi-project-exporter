namespace AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Models
{
    /// <summary>
    /// Identifies a single group item with target topic and custom class names
    /// </summary>
    public class RequestHomepageTabContentGroupItemUpdateModel
    {
        /// <summary>
        /// Unique id of the target topic for this item
        /// </summary>
        public Guid? TargetTopicId { get; set; }

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
