namespace AskDelphi.EditingAPI.DTO.Topic.Models
{
    /// <summary>
    /// Contains basic information about a topic version history entry
    /// </summary>
    public class ResponseTopicVersionHistoryTableModel
    {
        /// <summary>
        /// Topic version id
        /// </summary>
        public Guid TopicVersionId { get; set; }
        /// <summary>
        /// The parent version from which this topic is derived
        /// </summary>
        public Guid? ParentTopicVersionId { get; set; }
        /// <summary>
        /// Topic title at this version
        /// </summary>
        public string TopicTitle { get; set; }
        /// <summary>
        /// Major version no
        /// </summary>
        public int MajorVersionNo { get; set; }
        /// <summary>
        /// Minor version no
        /// </summary>
        public int MinorVersionNo { get; set; }
        /// <summary>
        /// Last modified date
        /// </summary>
        public DateTime DateModified { get; set; }
        /// <summary>
        /// Created by user full name claim
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Collection of stage titles for this topic version
        /// </summary>
        public List<string> StageTitles { get; set; }

        /// <summary>
        /// Comma delimited <see cref="StageTitles"/>
        /// </summary>
        public string StageTitleStr => string.Join(",", StageTitles ?? []);

        /// <summary>
        /// Versions of this topic
        /// </summary>
        public List<ResponseTopicVersionHistoryTableModel> Children { get; set; }

    }
}
