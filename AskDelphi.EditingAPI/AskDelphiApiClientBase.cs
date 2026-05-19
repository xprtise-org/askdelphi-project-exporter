using Microsoft.Extensions.Logging;
using RestSharp;

namespace AskDelphi.EditingAPI
{
    public abstract class AskDelphiApiClientBase
    {
        /// <summary>
        /// Creates an authenticated client for the AskDelphi REST API
        /// </summary>
        /// <returns></returns>
        protected static async Task<RestClient> CreateClient(IAskDelphiAPIContext context)
        {
            string bearerToken = await context.GetToken();
            RestClient client = new(context.URL)
            {
                AcceptedContentTypes = ["application/json"]
            };
            client.AddDefaultHeader("Authorization", $"Bearer {bearerToken}");
            return client;
        }


#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
#pragma warning disable CA2254 // Template should be a static expression
        protected static void LogAndThrowEditingApiRestRequestFailedException<T>(ILogger<T> logger, string message, params object?[] args)
        {
            logger.LogError(message, args);
            throw new EditingApiRestRequestFailedException(message);
        }
#pragma warning restore CA2254 // Template should be a static expression
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    }
}