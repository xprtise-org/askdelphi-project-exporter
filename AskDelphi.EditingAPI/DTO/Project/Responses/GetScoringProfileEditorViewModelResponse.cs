using AskDelphi.EditingAPI.DTO.Project.Models.ScoringProfile;

namespace AskDelphi.EditingAPI.DTO.Project.Responses
{
    /// <summary>
    /// Response object for fetching scoring project editor view model
    /// </summary>
    public class GetScoringProfileEditorViewModelResponse
    {
        /// <summary>
        /// Collection of view model object for scoring profile editor
        /// </summary>
        public List<ResponseScoringProfileEditorViewModel> Data { get; set; }
    }
}
