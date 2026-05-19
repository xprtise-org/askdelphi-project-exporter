namespace AskDelphi.EditingAPI.DTO.ExternalAdapter.Requests
{
    public class PostSearchExternalAdapterContentRequest
    {
        public string FolderId { get; set; }
        public string Query { get; set; }
        public string[] TopicTypes { get; set; }
    }
}
