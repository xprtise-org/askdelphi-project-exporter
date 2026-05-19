using AskDelphi.EditingAPI.DTO.Shared;

namespace AskDelphi.EditingAPI.DTO
{
    /// <summary>
    /// List of tags to be added to a topic
    /// </summary>
    public class PostTopicTagRequest
    {
        public IEnumerable<ResponseTagModel> Tags { get; set; }
    }
}
