namespace AskDelphi.EditingAPI.DTO
{
    public class GetTopicClassificationResponse
    {
        public TopicRoleBasedAccessControlModel Classification { get; set; }

    }

    public class TopicRoleBasedAccessControlModel
    {
        /// <summary></summary>
        public bool IsRoleBasedAccessSupported { get; set; }
        /// <summary></summary>
        public string[] SelectedNodeIds { get; set; }
    }
}
