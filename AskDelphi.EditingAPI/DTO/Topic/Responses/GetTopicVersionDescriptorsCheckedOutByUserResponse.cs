using AskDelphi.EditingAPI.DTO.Topic.Models;

namespace AskDelphi.EditingAPI.DTO.Topic.Responses
{
    /// <summary>
    /// Response with topic version descriptors checked-out by user
    /// </summary>
    public class GetTopicVersionDescriptorsCheckedOutByUserResponse
    {
        /// <summary>
        /// Collection of topic version descriptors checked-out by user
        /// </summary>
        public List<ResponseTopicVersionDescriptor> Data { get; set; }
    }
}
