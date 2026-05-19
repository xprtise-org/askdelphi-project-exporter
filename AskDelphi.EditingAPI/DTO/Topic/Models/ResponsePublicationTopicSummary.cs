namespace AskDelphi.EditingAPI.DTO.Topic.Models
{
    /// <summary>
    /// Contains information about topic publication status
    /// </summary>
    public class ResponsePublicationTopicSummary
    {
        /// <summary>
        /// Title of the tenant, which the topic belongs to
        /// </summary>
        public string TenantTitle { get; set; }

        /// <summary>
        /// Title of the hosting environment container, which the topic was published to
        /// </summary>
        public string HostingContainerName { get; set; }

        /// <summary>
        /// Title of the publication, which the topic was published to
        /// </summary>
        public string PublicationName { get; set; }

        /// <summary>
        /// Title of the topic type for this topic
        /// </summary>
        public string TopicType { get; set; }

        /// <summary>
        /// Namespace of this topic's topic type
        /// </summary>
        public string TopicNamespace { get; set; }

        /// <summary>
        /// Title of this topic for this topic version
        /// </summary>
        public string TopicTitle { get; set; }

        /// <summary>
        /// Indicates the details of publication status
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Indicate the name of the publication state for this topic version (published, queued etc)
        /// </summary>
        public string PublicationStateName { get; set; }

        /// <summary>
        /// The major version of this topic version
        /// </summary>
        public int TopicMajorVersion { get; set; }

        /// <summary>
        /// The minor version of this topic version
        /// </summary>
        public int TopicMinorVersion { get; set; }

        /// <summary>
        /// The last modification date of this topic version content
        /// </summary>
        public DateTime TopicVersionModificationDate { get; set; }

        /// <summary>
        /// The publication modification date of this topic version
        /// </summary>
        public DateTime LastModificationDate { get; set; }

        /// <summary>
        /// The id of the topic 
        /// </summary>
        public Guid TopicGuid { get; set; }

        /// <summary>
        /// Id of the tenant, which the topic belongs to
        /// </summary>
        public Guid TenantGuid { get; set; }

        /// <summary>
        /// Id of the hosting environment container, which the topic version was published to
        /// </summary>
        public Guid HostingContainerGuid { get; set; }

        /// <summary>
        /// The id of the publication, which the topic version was published to
        /// </summary>
        public Guid PublicationGuid { get; set; }

        /// <summary>
        /// The id of the topic version 
        /// </summary>
        public Guid TopicVersionGuid { get; set; }
    }
}
