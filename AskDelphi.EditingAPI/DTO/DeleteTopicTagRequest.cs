using AskDelphi.EditingAPI.DTO.Shared;

namespace AskDelphi.EditingAPI.DTO
{
    /// <summary>
    /// List of tags to be deleted
    /// </summary>
    public class DeleteTopicTagRequest
    {
        public IEnumerable<ResponseTagModel> Tags { get; set; }
    }
}
