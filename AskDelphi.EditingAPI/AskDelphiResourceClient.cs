using Microsoft.Extensions.Logging;
using RestSharp;

namespace AskDelphi.EditingAPI
{
    public class AskDelphiResourceClient(ILogger<AskDelphiResourceClient> logger) : AskDelphiApiClientBase, IAskDelphiResourceClient
    {
        private readonly ILogger<AskDelphiResourceClient> logger = logger;

        public async Task<byte[]> DownloadResource(IAskDelphiAPIContext context, Guid rescourceId)
        {
            RestClient client = await CreateClient(context);

            RestRequest request = new($"/v1/tenant/{context.TenantGuid}/project/{context.ProjectGuid}/acl/{context.AclGuid}/resource/{rescourceId}", Method.Get);
            byte[] response = await client.DownloadDataAsync(request);
            if (null == response)
            {
                logger.LogWarning("Null response on {Resource}", request.Resource);
            }
            return response;
        }

    }
}
