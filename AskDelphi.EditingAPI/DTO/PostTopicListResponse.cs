using AskDelphi.EditingAPI.DTO.Project;
using AskDelphi.EditingAPI.DTO.Topic.Responses;

namespace AskDelphi.EditingAPI.DTO
{
    public class PostTopicListResponse
    {
        public PagedResult<TopicListEntryIdentifier> TopicList { get; set; }
    }
}
