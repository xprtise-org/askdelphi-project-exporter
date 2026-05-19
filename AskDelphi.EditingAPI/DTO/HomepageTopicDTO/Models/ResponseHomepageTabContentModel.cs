using KeyValuePair = AskDelphi.EditingAPI.DTO.Shared.KeyValuePair;

namespace AskDelphi.EditingAPI.DTO.HomepageTopicDTO.Models
{
    /// <summary>
    /// Contains groups and columns, defined by user for a homepage tab
    /// </summary>
    public class ResponseHomepageTabContentModel
    {
        /// <summary>
        /// Collection of namespaces, used to restrict user topic selection when selecting target group item topic
        /// </summary>
        public IEnumerable<string> PortletTargets { get; set; }

        /// <summary>
        /// Collection topic namespace
        /// </summary>
        public string CollectionTopicNamespace { get; set; }

        /// <summary>
        /// Collection of all group layouts that a user can pick from. Also depending on group type, this collection is used to calculate allowed group layouts, that a user can pick from
        /// </summary>
        public IEnumerable<ResponseHomepageTabContentGroupLayout> GroupLayouts { get; set; }

        /// <summary>
        /// Collection of all tab layouts that a user can pick from for this tab.
        /// </summary>
        public IEnumerable<KeyValuePair> TabLayouts { get; set; }

        /// <summary>
        /// Collection of all group types that a user can pick from.
        /// </summary>
        public IEnumerable<KeyValuePair> GroupTypes { get; set; }

        /// <summary>
        /// Indicates the selected tab layout name (1-column, 2-columns-25-75 etc)
        /// </summary>
        public string SelectedTabLayout { get; set; }

        /// <summary>
        /// Collection of columns, defined for this homepage tab
        /// </summary>
        public IEnumerable<ResponseHomepageTabContentColumnModel> Columns { get; set; }
    }
}
