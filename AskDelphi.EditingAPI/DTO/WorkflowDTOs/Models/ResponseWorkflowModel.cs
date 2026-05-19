using AskDelphi.EditingAPI.DTO.ContactListDTOs.Models;
using AskDelphi.EditingAPI.DTO.Project.Models;

namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Models
{
    /// <summary>
    /// Represents a single workflow definition
    /// </summary>
    public class ResponseWorkflowModel
    {
        /// <summary>
        /// Unique id of the workflow
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Workflow title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Indicates if workflow is enabled
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// Indicates if all topic types are targeted by this workflow
        /// </summary>
        /// <remarks>
        /// This means that even if new topic types are added in the future, this workflow is still going to be applicable to them
        /// </remarks>
        public bool TargetAllTopicTypes { get; set; }

        /// <summary>
        /// Collection of sequenced stages for this workflow
        /// </summary>
        public List<ResponseWorkflowStageModel> Stages { get; set; }
        /// <summary>
        /// Collection of transitions for this workflow
        /// </summary>
        public List<ResponseWorkflowTransitionModel> Transitions { get; set; }
        /// <summary>
        /// Selected topic types, applicable to this workflow
        /// </summary>
        public List<ResponseTopicTypeDescriptor> SelectedTopicTypes { get; set; }

        /// <summary>
        /// All existing contact lists
        /// </summary>
        public List<ResponseContactListDescriptor> ExistingContactLists { get; set; }

        /// <summary>
        /// All existing non-deleted topic types
        /// </summary>
        public List<ResponseTopicTypeDescriptor> ExistingTopicTypes { get; set; }
    }
}
