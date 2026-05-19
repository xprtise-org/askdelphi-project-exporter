namespace AskDelphi.EditingAPI.DTO.TopicLearning.Models
{
    public class ResponseTopicLearningCompetencyGroup
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
        /// Indicates whether or not this node in the competency hierarchy is currentlys selected as a "competency group" for the source topic.
        /// </summary>
        public bool IsSelected { get; set; }

    }
}
