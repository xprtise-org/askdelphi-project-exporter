namespace AskDelphi.EditingAPI.DTO.TopicLearning.Models
{
    /// <summary>
    /// Competency Topic to CompetencyNode selection parameters
    /// </summary>
    public class RequestTopicCompetencyRelationSelection
    {
        /// <summary>
        /// Target CompetencyNodeId that a relation should be created to
        /// </summary>
        public Guid CompetencyNodeId { get; set; }
    }
}
