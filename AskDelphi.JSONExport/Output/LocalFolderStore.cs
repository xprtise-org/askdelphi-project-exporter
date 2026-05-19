using AskDelphi.ProjectPublisher;
using Microsoft.Extensions.Logging;

namespace AskDelphi.JSONExport.Output
{
    public class LocalFolderStore(ILogger<LocalFolderStore> logger, IPublicationSettings publicationSettings) : IPublicationTargetFilesystem
    {
        private readonly ILogger<LocalFolderStore> logger = logger;
        private readonly IPublicationSettings publicationSettings = publicationSettings;

        public async Task WriteText(string relativePath, string content, string contentType)
        {
            logger.LogTrace("Writing text to {Filename}", relativePath);
            string fullPath = Path.Combine(publicationSettings.BasePath, relativePath);
            string folder = Path.GetDirectoryName(fullPath) ?? ".";
            Directory.CreateDirectory(folder);
            await File.WriteAllTextAsync(fullPath, content);
        }

        public async Task WriteBytes(string relativePath, byte[] content, string contentType)
        {
            logger.LogTrace("Writing bytes to {Filename}", relativePath);
            string fullPath = Path.Combine(publicationSettings.BasePath, relativePath);
            string folder = Path.GetDirectoryName(fullPath) ?? ".";
            Directory.CreateDirectory(folder);
            await File.WriteAllBytesAsync(fullPath, content);
        }
    }
}
