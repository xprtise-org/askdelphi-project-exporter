namespace AskDelphi.EditingAPI.DTO.TopicLearning.Models
{
    public class ResponseTopicLearningCompetency
    {
        /// <summary>
        /// Hierarchy node id
        /// </summary>
        public Guid NodeId { get; set; }
        /// <summary>
        /// Path to competency node
        /// </summary>
        public string PathToNode { get; set; }
        /// <summary>
        /// Competency node title
        /// </summary>
        public string NodeTitle { get; set; }
        /// <summary>
        /// Indicates whether a relation already exists to this node
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// Collection of levels for the competency node
        /// </summary>
        public IEnumerable<ResponseTopicLearningCompetency> Levels { get; set; }

    }
}
