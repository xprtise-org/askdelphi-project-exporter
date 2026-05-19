using AskDelphi.EditingAPI.DTO;
using AskDelphi.EditingAPI.DTO.Topic.Requests;
using AskDelphi.EditingAPI.DTO.Topic.Responses;

namespace AskDelphi.EditingAPI
{
    public interface IAskDelphiTopicClient
    {
        Task<APIResponse<GetTopicContentPartsResponse>> GetContentTopicPartsV3(IAskDelphiAPIContext context, Guid topicGuid, Guid topicVersionId);
        Task<APIResponse<GetTopicEditorTagModelResponse>> GetTopicEditorTagModel(IAskDelphiAPIContext context, Guid topicGuid, Guid topicVersionId);
        Task<APIResponse<PostSearchTopicVersionHistoryTableResponse>> PostSearchTopicVersionHistoryTable(IAskDelphiAPIContext context, Guid topicGuid, PostSearchTopicVersionHistoryTableRequest requestParameters);
    }
}