namespace AskDelphi.ProjectPublisher
{
    public interface IPublicationTargetFilesystem
    {
        Task WriteText(string relativePath, string content, string contentType);
        Task WriteBytes(string relativePath, byte[] content, string contentType);
    }
}
