using AskDelphi.EditingAPI.DTO;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Text.Json;

namespace AskDelphi.EditingAPI.Authenticators
{
    public class BearerTokenAuthenticator(ILogger<BearerTokenAuthenticator> logger, BearerTokenAuthenticatorOptions options) : AskDelphiApiClientBase, IAdAPIAuthenticator
    {
        private string _token = null;
        private readonly ILogger<BearerTokenAuthenticator> logger = logger;
        private readonly BearerTokenAuthenticatorOptions options = options;

        public static string BaseURL(Uri uri)
        {
            return $"{uri.Scheme}://{uri.Host}";
        }

        public async Task<string> GetTokenAsync(AskDelphiAPIContext context)
        {
            if (_token != null && JwtUtils.GetExpiryTimestamp(_token) <= DateTime.UtcNow + TimeSpan.FromMinutes(1))
            {
                logger.LogInformation($"JWT token is about to expire, requesting a new token.");
                _token = null;
            }

            if (_token == null)
            {
                logger.LogInformation($"Requesting a fresh token.");
                RestClient client = await CreateClientForRefresh(context, BaseURL(new Uri(options.URL)));
                string requestURL = "/api/token/refresh";
                RestRequest request = new(requestURL, Method.Get);
                request.AddParameter("token", options.Token);
                request.AddParameter("refreshToken", options.RefreshToken);
                RestResponse<RefreshResponse> response = await client.ExecuteAsync<RefreshResponse>(request);
                if (!response.IsSuccessful)
                {
                    LogAndThrowEditingApiRestRequestFailedException(logger, $"{request.Method} request on {request.Resource} failed with status {response.StatusCode}/{response.StatusDescription}");
                }
                if (string.IsNullOrEmpty(response.Data.token))
                {
                    LogAndThrowEditingApiRestRequestFailedException(logger, $"{request.Method} request on {request.Resource} failed with error");
                }
                options.Token = response.Data.token;
                options.RefreshToken = response.Data.refresh;

                if (!string.IsNullOrWhiteSpace(options.TokenFilename))
                {
                    File.WriteAllText(options.TokenFilename, JsonSerializer.Serialize(options));
                }                

                _token = await RequestEditingAPITokenFromPublication(options.Token, BaseURL(new Uri(options.URL)));
            }

            return _token;
        }

        private async Task<string> RequestEditingAPITokenFromPublication(string token, string url)
        {
            RestClient client = new(url)
            {
                AcceptedContentTypes = ["application/json"]
            };
            RestRequest request = new("/api/token/EditingApiToken", Method.Get);
            client.AddDefaultHeader("Authorization", $"Bearer {token}");
            RestResponse<string> response = await client.ExecuteAsync<string>(request);
            if (!response.IsSuccessful)
            {
                LogAndThrowEditingApiRestRequestFailedException(logger, $"{request.Method} request on {request.Resource} failed with status {response.StatusCode}/{response.StatusDescription}");
            }
            if (string.IsNullOrEmpty(response.Data))
            {
                LogAndThrowEditingApiRestRequestFailedException(logger, $"{request.Method} request on {request.Resource} failed with error");
            }
            return response.Data;
        }

        private static async Task<RestClient> CreateClientForRefresh(AskDelphiAPIContext context, string url)
        {
            RestClient client = new(url)
            {
                AcceptedContentTypes = ["application/json"]
            };
            return await Task.FromResult(client);
        }

        public class RefreshResponse
        {
            public string token { get; set; }
            public string refresh { get; set; }
        }
    }
}
