using AskDelphi.EditingAPI.DTO.Shared;

namespace AskDelphi.EditingAPI.DTO
{
    public class GetTopicRelationsResponse
    {

        public IEnumerable<TopicRelationDefinition> Relations { get; set; }
    }
}
