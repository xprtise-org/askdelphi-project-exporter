namespace AskDelphi.EditingAPI.DTO
{
    /// <summary>
    /// Returns list of tags after adding requested tags
    /// </summary>
    public class PostTopicTagResponse
    {
        public IEnumerable<Shared.ResponseTagModel> Tags { get; set; }
    }
}
