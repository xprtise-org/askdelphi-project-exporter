using AskDelphi.ProjectPublisher;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace AskDelphi.JSONExport
{
    public class PublicationProcessFinalizer(ILogger<PublicationProcessFinalizer> logger, IPublicationTargetFilesystem fs) : IPublicationFinalizer
    {
        private readonly ILogger<PublicationProcessFinalizer> logger = logger;
        private readonly IPublicationTargetFilesystem fs = fs;
        private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

        public async Task Finalize(IAskdelphiPublisherContext context, PublicationResult publicationResult)
        {
            logger.LogTrace("Finalizing publication of project {ProjectGuid}", publicationResult.Project);
            publicationResult.BaseURL = context.URL;
            publicationResult.Project = context.ProjectGuid;
            publicationResult.Tenant = context.TenantGuid;
            publicationResult.ContentSet = context.ContentSet ?? [];
            await fs.WriteText("index.json", JsonSerializer.Serialize(publicationResult, jsonSerializerOptions), "application/json");
        }
    }
}
