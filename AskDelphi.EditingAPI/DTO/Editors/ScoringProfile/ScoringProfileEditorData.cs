namespace AskDelphi.EditingAPI.DTO.Editors.ScoringProfile
{
    /// <summary>
    /// Contains scoring profile editor data
    /// </summary>
    public class ScoringProfileEditorData
    {
        /// <summary>
        /// Selected profile (one of the profiles from project settings with atlist one scoring hierarchy defined)
        /// </summary>
        public string ScoringProfileId { get; set; }
        /// <summary>
        /// Collection of scoring hierarchy nodes selected by the user
        /// </summary>
        public List<ScoringProfileHierarchyNode> ScoringProfileHierarchyNodes { get; set; }
    }
}
