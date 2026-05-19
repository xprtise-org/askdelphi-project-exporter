using AskDelphi.EditingAPI.DTO.Project.Models;

namespace AskDelphi.EditingAPI.DTO.Project.Responses
{
    /// <summary>
    /// Response object, containing topic list filters, that can used to filter topic list
    /// Calculated based on project settings and content design for the requested tenant and project
    /// </summary>
    public class GetTopicListFilterResponse
    {
        /// <summary>
        /// Contains topic list filter information
        /// </summary>
        public ResponseTopicListFilter Data { get; set; }
    }
}
