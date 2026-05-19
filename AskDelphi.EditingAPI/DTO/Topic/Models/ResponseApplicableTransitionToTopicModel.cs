using AskDelphi.EditingAPI.DTO.WorkflowDTOs.Models;

namespace AskDelphi.EditingAPI.DTO.Topic.Models
{
    /// <summary>
    /// Information about applicable transitions for a topic version
    /// </summary>
    public class ResponseApplicableTransitionToTopicModel
    {
        /// <summary>
        /// Indicates that transitions exist where source stage is set and matches topic version stage
        /// </summary>
        public bool HasTransitionsWithMatchingSourceStage { get; set; }
        /// <summary>
        /// Transitions with no source stage or source stage matching topic version stage
        /// </summary>
        public List<ResponseWorkflowTransitionSelector> ApplicableTransitions { get; set; }
    }
}
