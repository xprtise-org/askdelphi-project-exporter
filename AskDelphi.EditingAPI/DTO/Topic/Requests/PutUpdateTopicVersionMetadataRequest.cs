using KeyValuePair = AskDelphi.EditingAPI.DTO.Shared.KeyValuePair;

namespace AskDelphi.EditingAPI.DTO.Topic.Requests
{
    /// <summary>
    /// Request object containing metadata values
    /// </summary>
    public class PutUpdateTopicVersionMetadataRequest
    {
        /// <summary>
        /// Metadata values
        /// </summary>
        public IEnumerable<KeyValuePair> Data { get; set; }
    }
}
