namespace AskDelphi.EditingAPI.DTO
{
    /// <summary>
    /// Returns list of tags after deleting requested tags
    /// </summary>
    public class DeleteTopicTagResponse
    {
        public IEnumerable<Shared.ResponseTagModel> Tags { get; set; }
    }
}

