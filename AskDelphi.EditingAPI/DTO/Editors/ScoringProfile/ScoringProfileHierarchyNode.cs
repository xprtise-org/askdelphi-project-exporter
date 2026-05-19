namespace AskDelphi.EditingAPI.DTO.Editors.ScoringProfile
{
    public class ScoringProfileHierarchyNode
    {
        /// <summary>
        /// Selected hierarchy from the selected scoring profile
        /// </summary>
        public Guid? ScoringHierarchyId { get; set; }
        /// <summary>
        /// Selected nodes from the scoring hierarchy
        /// </summary>
        public List<string> SelectedNodeIds { get; set; }

        /// <summary>
        /// When set <see cref="SelectedNodeIds"/> are disregarded in favor of hierarchy nodes from user's profile
        /// </summary>
        /// <remarks>
        /// If <see cref="ScoringHierarchyId"/> is role hierarchy, selected nodes are those tags that are used for the user’s primary and secondary role(s) as boosted node values,
        /// If <see cref="ScoringHierarchyId"/> is profile-hierarchy, selected nodes are those from user profile choices
        /// </remarks>
        public bool IsBasedOnUsersProfileSelection { get; set; }
    }
}
