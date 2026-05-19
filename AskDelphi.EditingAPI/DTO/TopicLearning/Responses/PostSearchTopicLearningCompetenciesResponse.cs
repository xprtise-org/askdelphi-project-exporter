using AskDelphi.EditingAPI.DTO.TopicLearning.Models;

namespace AskDelphi.EditingAPI.DTO.TopicLearning.Responses
{
    /// <summary>
    /// Response object containing search result data
    /// </summary>
    public class PostSearchTopicLearningCompetenciesResponse
    {
        /// <summary>
        /// Indicates whether the current topic is a competency topic type, based on project settings
        /// </summary>
        public bool IsCompetencyTopic { get; set; }
        /// <summary>
        /// Details of the search result containing information about available learning competencies nodes and levels nodes
        /// </summary>
        public IEnumerable<ResponseTopicLearningCompetency> Data { get; set; }

        /// <summary>
        /// Details of the search result containing information about available competency group nodes
        /// </summary>
        public IEnumerable<ResponseTopicLearningCompetencyGroup> CompetencyGroups { get; set; }

    }
}
