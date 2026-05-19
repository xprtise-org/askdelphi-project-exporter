using AskDelphi.EditingAPI.DTO.Project.Models;
using AskDelphi.EditingAPI.DTO.Shared;
using AskDelphi.EditingAPI.DTO.Shared.Models;

namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Models
{
    /// <summary>
    /// Contains content set rules defined for this workflow transition request
    /// </summary>
    public class ResponseWorkflowTransitionRequestContentSetModel : ResponseWorkflowTransitionRequestBaseModel
    {
        /// <summary>
        /// Content set definition
        /// </summary>
        /// <remarks>
        /// Used to idetify the topics to which this request will apply
        /// </remarks>
        public List<ResponseContentSetRuleModel> ContentSetRules { get; set; }

        /// <summary>
        /// Collection of all non-deleted topic types for this project
        /// </summary>
        public List<ResponseTopicTypeDescriptor> ExistingTopicTypes { get; set; }

        /// <summary>
        /// Collection of existing hierarchy tags for this project
        /// </summary>
        public List<ResponseTagModelBase> ExistingTags { get; set; }
    }
}
