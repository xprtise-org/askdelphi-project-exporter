using AskDelphi.EditingAPI.DTO;
using AskDelphi.EditingAPI.DTO.Topic.Requests;
using AskDelphi.EditingAPI.DTO.Topic.Responses;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace AskDelphi.EditingAPI
{
    public class AskDelphiTopicClient(ILogger<AskDelphiTopicClient> logger) : AskDelphiApiClientBase, IAskDelphiTopicClient
    {
        private readonly ILogger<AskDelphiTopicClient> logger = logger;

        public async Task<APIResponse<PostSearchTopicVersionHistoryTableResponse>> PostSearchTopicVersionHistoryTable(IAskDelphiAPIContext context, Guid topicGuid, PostSearchTopicVersionHistoryTableRequest requestParameters)
        {
            RestClient client = await CreateClient(context);

            RestRequest request = new($"/v1/tenant/{context.TenantGuid}/project/{context.ProjectGuid}/acl/{context.AclGuid}/topic/{topicGuid}/topic-version-history-table-entries", Method.Post);
            request.AddJsonBody<PostSearchTopicVersionHistoryTableRequest>(requestParameters);
            RestResponse<APIResponse<PostSearchTopicVersionHistoryTableResponse>> response = await client.ExecuteAsync<APIResponse<PostSearchTopicVersionHistoryTableResponse>>(request);
            if (!response.IsSuccessful)
            {
                LogAndThrowEditingApiRestRequestFailedException(logger, $"{request.Method} request on {request.Resource} failed with status {response.StatusCode}/{response.StatusDescription}");
            }
            if (!response.Data.Success)
            {
                LogAndThrowEditingApiRestRequestFailedException(logger, $"{request.Method} request on {request.Resource} failed with API error {response.Data.ErrorCode}/{response.Data.ErrorMessage}");
            }
            return response.Data;
        }

        public async Task<APIResponse<GetTopicEditorTagModelResponse>> GetTopicEditorTagModel(IAskDelphiAPIContext context, Guid topicGuid, Guid topicVersionId)
        {
            RestClient client = await CreateClient(context);

            RestRequest request = new($"/v1/tenant/{context.TenantGuid}/project/{context.ProjectGuid}/acl/{context.AclGuid}/topic/{topicGuid}/topicVersion/{topicVersionId}/editortagmodel", Method.Get);
            RestResponse<APIResponse<GetTopicEditorTagModelResponse>> response = await client.ExecuteAsync<APIResponse<GetTopicEditorTagModelResponse>>(request);
            if (!response.IsSuccessful)
            {
                LogAndThrowEditingApiRestRequestFailedException(logger, $"{request.Method} request on {request.Resource} failed with status {response.StatusCode}/{response.StatusDescription}");
            }
            if (!response.Data.Success)
            {
                LogAndThrowEditingApiRestRequestFailedException(logger, $"{request.Method} request on {request.Resource} failed with API error {response.Data.ErrorCode}/{response.Data.ErrorMessage}");
            }
            return response.Data;
        }

        public async Task<APIResponse<GetTopicContentPartsResponse>> GetContentTopicPartsV3(IAskDelphiAPIContext context, Guid topicGuid, Guid topicVersionId)
        {
            RestClient client = await CreateClient(context);

            RestRequest request = new($"/v3/tenant/{context.TenantGuid}/project/{context.ProjectGuid}/acl/{context.AclGuid}/topic/{topicGuid}/topicVersion/{topicVersionId}/part", Method.Get);
            RestResponse<APIResponse<GetTopicContentPartsResponse>> response = await client.ExecuteAsync<APIResponse<GetTopicContentPartsResponse>>(request);
            if (!response.IsSuccessful)
            {
                LogAndThrowEditingApiRestRequestFailedException(logger, $"{request.Method} request on {request.Resource} failed with status {response.StatusCode}/{response.StatusDescription}");
            }
            if (!response.Data.Success)
            {
                LogAndThrowEditingApiRestRequestFailedException(logger, $"{request.Method} request on {request.Resource} failed with API error {response.Data.ErrorCode}/{response.Data.ErrorMessage}");
            }
            return response.Data;
        }

    }
}
