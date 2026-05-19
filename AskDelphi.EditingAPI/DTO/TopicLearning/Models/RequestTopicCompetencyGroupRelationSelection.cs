namespace AskDelphi.EditingAPI.DTO.TopicLearning.Models
{
    /// <summary>
    /// Topic to CompetencyGroupNode selection parameters
    /// </summary>
    public class RequestTopicCompetencyGroupRelationSelection
    {
        /// <summary>
        /// Target competencyGroupNode id that a relation should be created to
        /// </summary>
        public Guid CompetencyGroupNodeId { get; set; }
    }
}
