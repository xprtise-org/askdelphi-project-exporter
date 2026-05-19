namespace AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Models
{
    /// <summary>
    /// Identifies a group layout by name with corresponding keywords (used to calculate allowed layouts for selected <seealso cref="ResponseHomepageTabContentGroupModel.GroupType"/>)
    /// </summary>
    public class ResponseHomepageTabContentGroupLayout
    {
        /// <summary>
        /// Indicates the name of the layout (E.g. layout 1, layout 2)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates the keywords that correspond to this layout.
        /// Based on selected <seealso cref="ResponseHomepageTabContentGroupModel.GroupType"/>, the keywords are used to calculate allowed layouts for the <seealso cref="ResponseHomepageTabContentGroupModel.GroupType"/>
        /// </summary>
        public string KeyWords { get; set; }
    }
}
