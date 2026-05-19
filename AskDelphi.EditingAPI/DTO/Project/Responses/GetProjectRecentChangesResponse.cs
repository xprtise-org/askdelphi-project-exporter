using AskDelphi.EditingAPI.DTO.Project.Models;

namespace AskDelphi.EditingAPI.DTO.Project.Responses
{
    /// <summary>
    /// Response object containing project recent changes
    /// </summary>
    public class GetProjectRecentChangesResponse
    {
        /// <summary>
        /// Details of recent changes
        /// </summary>
        public IEnumerable<ResponseProjectEventLogModel> Data { get; set; }
    }
}
