namespace AskDelphi.EditingAPI.DTO.User.Models
{
    /// <summary>
    /// Contains role definition
    /// </summary>
    public class ResponseRoleDefinition
    {
        /// <summary>
        /// Unique role id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Role title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Indicates whether role grants permission to view all topics
        /// </summary>
        public bool CanViewAllTopics { get; set; }
        /// <summary>
        /// Indicates whether role grants permission to add local topics of types
        /// </summary>
        public Guid[] CanAddLocalTopicsOfTypes { get; set; }
        /// <summary>
        /// Indicates whether role grants permission to add external topics of types
        /// </summary>
        public Guid[] CanAddExternalTopicsOfTypes { get; set; }
        /// <summary>
        /// Indicates whether role grants permission to add external topics from sources, an array of adapter ids
        /// </summary>
        public string[] CanAddExternalTopicsFromSources { get; set; }
        /// <summary>
        /// Indicates whether role grants permission to edit all topics
        /// </summary>
        public bool CanEditOrAddAllTopics { get; set; }
        /// <summary>
        /// Indicates whether role grants permission to edit/add topics with specified tags
        /// </summary>
        public ResponseAccessControlTagModel[] EnforcedTags { get; set; }
        /// <summary>
        /// Indicates whether role grants permission to force check in or force checkout a topic
        /// </summary>
        public bool CanBreakLocks { get; set; }
        /// <summary>
        /// Indicates whether role grants project administrator permissions/all access
        /// </summary>
        public bool IsProjectAdmin { get; set; }
        /// <summary>
        /// Indicates if this role is simply used for triggering remote endpoint
        /// </summary>
        public bool TriggerRemoteEndpoint { get; set; }
    }
}
