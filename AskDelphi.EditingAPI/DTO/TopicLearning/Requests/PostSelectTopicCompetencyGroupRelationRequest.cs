using AskDelphi.EditingAPI.DTO.TopicLearning.Models;

namespace AskDelphi.EditingAPI.DTO.TopicLearning.Requests
{
    /// <summary>
    /// Request to Post SelectTopicCompetencyGroupRelation, to create a tag relation between a topic and a node in the competency hierarchy representing a "CompetencyGroup"
    /// </summary>
    public class PostSelectTopicCompetencyGroupRelationRequest
    {
        /// <summary>
        /// CompetencyGroup node selection params
        /// </summary>
        public RequestTopicCompetencyGroupRelationSelection Data { get; set; }
    }
}
