using AskDelphi.EditingAPI.DTO;

namespace AskDelphi.EditingAPI
{
    public interface IAskDelphiRelationsClient
    {
        Task<APIResponse<GetTopicRelationsCategorizedResponse>> GetRelationsCategorized(IAskDelphiAPIContext context, Guid topicId, Guid topicVersionId, string externalUri);
    }
}