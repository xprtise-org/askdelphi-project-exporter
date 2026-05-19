using AskDelphi.EditingAPI.DTO;

namespace AskDelphi.EditingAPI
{
    public interface IAskDelphiProjectClient
    {
        Task<APIResponse<GetContentDesignResponse>> GetContentDesign(IAskDelphiAPIContext context);
        Task<APIResponse<PostTopicListResponse>> PostTopicListRequest(IAskDelphiAPIContext context, PostTopicListRequest requestParameters);
    }
}