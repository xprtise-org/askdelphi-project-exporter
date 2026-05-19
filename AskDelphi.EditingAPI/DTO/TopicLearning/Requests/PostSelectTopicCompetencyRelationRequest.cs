using AskDelphi.EditingAPI.DTO.TopicLearning.Models;

namespace AskDelphi.EditingAPI.DTO.TopicLearning.Requests
{
    /// <summary>
    /// Request to Post SelectTopicCompetencyRelation, to create a tag relation between a topic and a node in the competency hierarchy representing a "Competency"
    /// </summary>
    public class PostSelectTopicCompetencyRelationRequest
    {
        /// <summary>
        /// Competency Topic to CompetencyNode selection parameters, including the target hierarchy node identifier
        /// </summary>
        public RequestTopicCompetencyRelationSelection Data { get; set; }
    }
}
