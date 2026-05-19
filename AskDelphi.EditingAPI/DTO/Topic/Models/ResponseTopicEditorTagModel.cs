using AskDelphi.EditingAPI.DTO.Shared;

namespace AskDelphi.EditingAPI.DTO.Topic.Models
{
    /// <summary>
    /// Response object containing tag information required for topic editor
    /// </summary>
    public class ResponseTopicEditorTagModel
    {
        /// <summary>
        /// Contains all classifications for project
        /// </summary>
        public IEnumerable<Project.RoleBasedAccessControlTag> Classifications { get; set; }

        /// <summary>
        /// Contains all tags for project
        /// </summary>
        public IEnumerable<ResponseTagModel> ProjectTags { get; set; }

        /// <summary>
        /// Contains tags for topic
        /// </summary>
        public IEnumerable<ResponseTagModel> TopicTags { get; set; }

        /// <summary>
        /// Role based access control model for topic
        /// </summary>
        public ResponseTopicRoleBasedAccessControlModel TopicRoleBasedAccessControlModel { get; set; }
    }
}
