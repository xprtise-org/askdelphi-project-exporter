using AskDelphi.EditingAPI.DTO.Project.Models;

namespace AskDelphi.EditingAPI.DTO.Topic.Responses
{
    public class GetViewModelForTopicTypeChangeResponse
    {
        /// <summary>
        /// Collection of topic types with matching namespace from specified topic
        /// </summary>
        public List<ResponseTopicTypeDescriptor> TopicTypesWithMatchingNamespaces { get; set; }
    }

}