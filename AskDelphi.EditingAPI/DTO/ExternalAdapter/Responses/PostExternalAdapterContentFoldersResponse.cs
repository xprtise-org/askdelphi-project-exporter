using AskDelphi.EditingAPI.DTO.ExternalAdapter.Models;

namespace AskDelphi.EditingAPI.DTO.ExternalAdapter.Responses
{
    public class PostExternalAdapterContentFoldersResponse
    {
        public IEnumerable<ResponseExternalAdapterFolderDescriptor> Data { get; set; }
    }
}
