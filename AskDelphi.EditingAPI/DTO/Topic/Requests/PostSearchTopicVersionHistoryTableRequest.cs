namespace AskDelphi.EditingAPI.DTO.Topic.Requests
{
    public class PostSearchTopicVersionHistoryTableRequest
    {
        /// <summary>
        /// When set will only search for topic versions with stages
        /// </summary>
        public bool ExcludeVersionsWithoutStages { get; set; }
    }
}
