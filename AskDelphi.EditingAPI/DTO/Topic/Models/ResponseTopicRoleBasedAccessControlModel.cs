namespace AskDelphi.EditingAPI.DTO.Topic.Models
{
    /// <summary>
    /// Contains information about topics rbac nodes
    /// </summary>
    public class ResponseTopicRoleBasedAccessControlModel
    {
        /// <summary>
        /// Indicates whether rbac is supported for topics
        /// </summary>
        public bool IsRoleBasedAccessSupported { get; set; }
        /// <summary>
        /// Contains selected rbac node ids
        /// </summary>
        public string[] SelectedNodeIds { get; set; }
    }

}
