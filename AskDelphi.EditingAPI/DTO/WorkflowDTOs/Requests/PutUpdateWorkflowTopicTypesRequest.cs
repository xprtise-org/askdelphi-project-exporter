using System.ComponentModel.DataAnnotations;

namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Requests
{
    /// <summary>
    /// Request object containing information about selected topic types applicable to the workflow
    /// </summary>
    public class PutUpdateWorkflowTopicTypesRequest
    {
        /// <summary>
        /// Indicates if all topic types are applicable for this workflow
        /// </summary>
        [Required]
        public bool TargetAllTopicTypes { get; set; }

        /// <summary>
        /// Selected topic type ids
        /// </summary>
        public List<Guid> TopicTypesIds { get; set; }
    }
}
