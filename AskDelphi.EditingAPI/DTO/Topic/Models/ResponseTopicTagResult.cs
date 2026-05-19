namespace AskDelphi.EditingAPI.DTO.Topic.Models
{

    /// <summary>
    /// Topic tagging or untagging information
    /// </summary>
    public class ResponseTopicTagResult
    {
        // topic guid that the user requested to make tagging or untagging
        public Guid TopicId { get; set; }

        // title of the topic
        public string TopicTitle { get; set; }

        // result of tagging or untagging
        public bool Success { get; set; }

        // error information provided to the user, to make them aware what went wrong
        public ResponseTopicTagResultError Error { get; set; }
    }
}
