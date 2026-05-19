using KeyValuePair = AskDelphi.EditingAPI.DTO.Shared.KeyValuePair;

namespace AskDelphi.EditingAPI.DTO.Project.Models.ScoringProfile
{
    /// <summary>
    /// Scoring profile editor facet/hierarchy view model
    /// </summary>
    public class ResponseScoringProfileEditorFacetWeightViewModel
    {
        /// <summary>
        /// Scoring profile hierarchy id
        /// </summary>
        public Guid HierarchyGuid { get; set; }
        /// <summary>
        /// Scoring profile hierarchy name
        /// </summary>
        public string HierarchyName { get; set; }

        /// <summary>
        /// Flat list of all nodes in the hierarchy
        /// </summary>
        /// <remarks>
        /// <see cref="KeyValuePair.Key"/> is node id while <see cref="KeyValuePair.Value"/> is node name
        /// </remarks>
        public List<KeyValuePair> Nodes { get; set; }
    }
}
