namespace AskDelphi.EditingAPI.DTO.Topic.Models
{
    /// <summary>
    /// Error information returns from ServiceCallResult
    /// </summary>
    public class ResponseTopicTagResultError
    {
        // http status code
        public int StatusCode { get; set; }

        // cause of tagging or untagging failure
        public string Message { get; set; }
    }
}
