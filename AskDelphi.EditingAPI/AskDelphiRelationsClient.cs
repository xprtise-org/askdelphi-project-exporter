using AskDelphi.EditingAPI.DTO;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace AskDelphi.EditingAPI
{
    public class AskDelphiRelationsClient(ILogger<AskDelphiRelationsClient> logger) : AskDelphiApiClientBase, IAskDelphiRelationsClient
    {
        private readonly ILogger<AskDelphiRelationsClient> logger = logger;

        public async Task<APIResponse<GetTopicRelationsCategorizedResponse>> GetRelationsCategorized(IAskDelphiAPIContext context, Guid topicId, Guid topicVersionId, string externalUri)
        {
            RestClient client = await CreateClient(context);

            RestRequest request = new($"/v2/tenant/{context.TenantGuid}/project/{context.ProjectGuid}/acl/{context.AclGuid}/topic/{topicId}/topicVersion/{topicVersionId}/relation/categorized", Method.Get);
            RestResponse<APIResponse<GetTopicRelationsCategorizedResponse>> response = await client.ExecuteAsync<APIResponse<GetTopicRelationsCategorizedResponse>>(request);
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
