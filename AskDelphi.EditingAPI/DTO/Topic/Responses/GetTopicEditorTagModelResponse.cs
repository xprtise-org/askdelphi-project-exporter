using AskDelphi.EditingAPI.DTO.Topic.Models;

namespace AskDelphi.EditingAPI.DTO.Topic.Responses
{
    /// <summary>
    /// Contains all information about topic tags, required to perform tagging operations
    /// </summary>
    public class GetTopicEditorTagModelResponse
    {
        /// <summary>
        /// Contains the topic editor tag model
        /// </summary>
        public ResponseTopicEditorTagModel Data { get; set; }
    }
}
