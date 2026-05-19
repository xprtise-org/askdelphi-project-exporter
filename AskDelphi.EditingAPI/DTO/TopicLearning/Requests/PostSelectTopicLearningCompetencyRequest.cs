using AskDelphi.EditingAPI.DTO.TopicLearning.Models;

namespace AskDelphi.EditingAPI.DTO.TopicLearning.Requests
{
    /// <summary>
    /// Request to Post SelectTopicLearningCompetency, to create a tag relation between a topic and a node in the competency hierarchy representing a "learning" on a specific level
    /// </summary>
    public class PostSelectTopicLearningCompetencyRequest
    {
        /// <summary>
        /// Learning competency selection parameters
        /// </summary>
        public RequestTopicLearningCompetencySelection Data { get; set; }
    }
}
