namespace AskDelphi.EditingAPI.DTO.TopicLearning.Models
{
    public class RequestTopicLearningCompetencySelection
    {
        /// <summary>
        /// Target competency node id that a relation should be created to
        /// </summary>
        public Guid CompetencyNodeId { get; set; }
        /// <summary>
        /// Target level node id that a relation should be created to, incase the topic is a non competency topic
        /// </summary>
        public Guid? LevelNodeId { get; set; }
    }
}
