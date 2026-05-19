using AskDelphi.EditingAPI.DTO.ExternalSourceTopic.Models;

namespace AskDelphi.EditingAPI.DTO.ExternalSourceTopic.Responses
{
    /// <summary>
    /// Response object, containing information about the success/failure of created topics
    /// </summary>
    public class PostCreateExternalSourceTopicResponseV2
    {
        public IEnumerable<ResponseExternalSourceTopicEntryResult> Data { get; set; }
    }
}
