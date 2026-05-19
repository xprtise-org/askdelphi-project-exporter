
namespace AskDelphi.EditingAPI
{
    public interface IAskDelphiResourceClient
    {
        Task<byte[]> DownloadResource(IAskDelphiAPIContext context, Guid rescourceId);
    }
}