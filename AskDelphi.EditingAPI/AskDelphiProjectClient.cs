using AskDelphi.EditingAPI.DTO;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace AskDelphi.EditingAPI
{
    public class AskDelphiProjectClient(ILogger<AskDelphiProjectClient> logger) : AskDelphiApiClientBase, IAskDelphiProjectClient
    {
        private readonly ILogger<AskDelphiProjectClient> logger = logger;

        public async Task<APIResponse<PostTopicListResponse>> PostTopicListRequest(IAskDelphiAPIContext context, PostTopicListRequest requestParameters)
        {
            RestClient client = await CreateClient(context);

            RestRequest request = new($"/v1/tenant/{context.TenantGuid}/project/{context.ProjectGuid}/acl/{context.AclGuid}/topiclist", Method.Post);
            request.AddJsonBody<PostTopicListRequest>(requestParameters);
            RestResponse<APIResponse<PostTopicListResponse>> response = await client.ExecuteAsync<APIResponse<PostTopicListResponse>>(request);
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

        public async Task<APIResponse<GetContentDesignResponse>> GetContentDesign(IAskDelphiAPIContext context)
        {
            RestClient client = await CreateClient(context);

            RestRequest request = new($"/v1/tenant/{context.TenantGuid}/project/{context.ProjectGuid}/acl/{context.AclGuid}/contentdesign", Method.Get);
            RestResponse<APIResponse<GetContentDesignResponse>> response = await client.ExecuteAsync<APIResponse<GetContentDesignResponse>>(request);
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
