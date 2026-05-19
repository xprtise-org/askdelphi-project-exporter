using AskDelphi.EditingAPI.DTO.WorkflowDTOs.Models;

namespace AskDelphi.EditingAPI.DTO.Topic.Models
{
    /// <summary>
    /// Model containing various options that a user can select from when checking-in a topic with respect to a workflow transition and stage assignment
    /// </summary>
    public class ResponseTopicCheckInWorkflowOptions
    {
        /// <summary>
        /// Contains a collection of stages from parent topic version (i.e. checked-out topic version)
        /// </summary>
        /// <remarks>
        /// These stages are primarily used when performing a minor change on a topic and thereafter checking-in with the stage of the parent topic version
        /// </remarks>
        public List<ResponseWorkflowStageSelector> Stages { get; set; }

        /// <summary>
        /// List of active workflow transitions
        /// </summary>
        /// <remarks>
        /// The source stage of these transitions must be from (Any/not specified)
        /// </remarks>
        public List<ResponseWorkflowTransitionSelector> Transitions { get; set; }
    }
}
