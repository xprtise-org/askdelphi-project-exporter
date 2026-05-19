namespace AskDelphi.EditingAPI.DTO.Project.Models.ScoringProfile
{
    /// <summary>
    /// View model object for scoring profile editor
    /// </summary>
    public class ResponseScoringProfileEditorViewModel
    {
        /// <summary>
        /// Profile unique id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Profile title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Collection of scoring hierarchies with nodes
        /// </summary>
        public List<ResponseScoringProfileEditorFacetWeightViewModel> Facets { get; set; }
    }
}
