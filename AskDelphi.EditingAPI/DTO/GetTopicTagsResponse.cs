using AskDelphi.EditingAPI.DTO.Shared;

namespace AskDelphi.EditingAPI.DTO
{
    /// <summary>
    /// Returns a list of all tags for a topic
    /// </summary>
    public class GetTopicTagsResponse
    {
        public GetTopicTagsResponse() { }

        public IEnumerable<ResponseTagModel> Tags { get; set; }
    }
}
