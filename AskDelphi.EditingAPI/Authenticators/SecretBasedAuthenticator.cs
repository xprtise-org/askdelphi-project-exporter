using AskDelphi.EditingAPI.DTO;
using AskDelphi.EditingAPI.DTO.Shared;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace AskDelphi.EditingAPI.Authenticators
{
    public class SecretBasedAuthenticator(ILogger<SecretBasedAuthenticator> logger, SecretsBasedAuthenticatorOptions options) : AskDelphiApiClientBase, IAdAPIAuthenticator
    {
        private string _token = null;
        private readonly ILogger<SecretBasedAuthenticator> logger = logger;
        private readonly SecretsBasedAuthenticatorOptions options = options;

        public async Task<string> GetTokenAsync(AskDelphiAPIContext context)
        {

            if (_token != null && JwtUtils.GetExpiryTimestamp(_token) <= DateTime.UtcNow + TimeSpan.FromMinutes(1))
            {
                logger.LogInformation($"JWT token is about to expire, requesting a new token.");
                _token = null;
            }

            if (_token == null)
            {
                // Log in using an API key
                string requestURL = "/v1/auth/key";
                    ClaimTuple[] body = [
                    new() { Type = "https://tempuri.org/askdelphi/editor2/upn", Value = options.ImpersonationUPN },
                    new() { Type = "https://tempuri.org/askdelphi/editor2/fullname", Value = options.ImpersonationFullName },
                    new() { Type = "https://tempuri.org/askdelphi/editor2/email", Value = options.ImpersonationEmail },
                    new() { Type = "https://tempuri.org/askdelphi/editor2/tenant", Value = $"{context.TenantGuid}" },
                    new() { Type = "https://tempuri.org/askdelphi/editor2/project", Value = $"{context.ProjectGuid}" },
                    // new() { Type = "https://tempuri.org/askdelphi/editor2/host", Value = "" },
                    // new() { Type = "https://tempuri.org/askdelphi/editor2/publication", Value = $"" },
                ];

                RestClient client = await CreateClientForBearerToken(context);
                RestRequest request = new(requestURL, Method.Post);
                request.AddJsonBody(body);
                RestResponse<APIResponse<GetTokenResponse>> response = await client.ExecuteAsync<APIResponse<GetTokenResponse>>(request);
                if (!response.IsSuccessful)
                {
                    LogAndThrowEditingApiRestRequestFailedException(logger, $"{request.Method} request on {request.Resource} failed with status {response.StatusCode}/{response.StatusDescription}");
                }
                if (!response.Data.Success)
                {
                    LogAndThrowEditingApiRestRequestFailedException(logger, $"{request.Method} request on {request.Resource} failed with API error {response.Data.ErrorCode}/{response.Data.ErrorMessage}");
                }
                _token = response.Data.Response?.Token;
            }

            return _token;
        }

        private async Task<RestClient> CreateClientForBearerToken(AskDelphiAPIContext context)
        {
            RestClient client = new($"{context.URL}")
            {
                AcceptedContentTypes = ["application/json"]
            };
            client.AddDefaultHeader("Authorization", $"Bearer {options.Secret}");
            return await Task.FromResult(client);
        }
    }
}
