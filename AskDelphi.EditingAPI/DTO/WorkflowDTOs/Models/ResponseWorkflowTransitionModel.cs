using AskDelphi.EditingAPI.DTO.ContactListDTOs.Models;

namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Models
{
    /// <summary>
    /// Represents a single workflow transition definition
    /// </summary>
    public class ResponseWorkflowTransitionModel
    {
        /// <summary>
        /// Unique id of the transition
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Title of the transition
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Indicates if transition is enabled
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// Indicates if the source stage should be cleared after the transition is completed
        /// </summary>
        public bool ClearSourceStage { get; set; }
        /// <summary>
        /// Indicates if the transition is only available to admins
        /// </summary>
        public bool OnlyAvailableToProjectAdmins { get; set; }
        /// <summary>
        /// The source stage for this transition
        /// </summary>
        /// <remarks>
        /// Can be null, in which case all stages are applicable for this transition
        /// </remarks>
        public ResponseWorkflowStageDescriptor SourceStage { get; set; }
        /// <summary>
        /// Represents the target stage of this transition
        /// </summary>
        /// <remarks>
        /// After the transition is completed, this is the stage that the topic versions will be at
        /// </remarks>
        public ResponseWorkflowStageDescriptor TargetStage { get; set; }
        /// <summary>
        /// Optional contact list for approval
        /// </summary>
        /// <remarks>
        /// When set, will require approval from member of the contact list
        /// </remarks>
        public ResponseContactListDescriptor ApproverContactList { get; set; }
    }
}
