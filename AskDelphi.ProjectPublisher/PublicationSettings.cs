using System.Text.Json.Serialization;

namespace AskDelphi.ProjectPublisher
{
    public class PublicationSettings : IPublicationSettings
    {
        /// <summary>
        /// Base path for folder output
        /// </summary>
        public string BasePath { get; set; } = ".";
        /// <summary>
        /// Base URL of the target publication, if known.
        /// </summary>
        public string BaseURL { get; set; } = "/";

        /// <summary>
        /// Tenant that this publication is for.
        /// </summary>
        public Guid TenantGuid { get; set; }

        /// <summary>
        /// Project that this publication is for.
        /// </summary>
        public Guid ProjectGuid { get; set; }

        /// <summary>
        /// ACL that this publication is for.
        /// </summary>
        public Guid AclGuid { get; set; }

        /// <summary>
        /// Identifies the workflow stage that's used for publishing content.
        /// </summary>
        public required string WorkflowStageTitle { get; set; }

        /// <summary>
        /// Definition of the publication contents.
        /// </summary>
        public List<RuleConfiguration> ContentSet { get; set; } = [];

        /// <summary>
        /// Structured like this for easy serailization, not for easy configuration
        /// </summary>
        public class RuleConfiguration
        {
            [JsonConverter(typeof(JsonStringEnumConverter))]
            public RuleType Type { get; set; }
            public IncludeSpecificTopicData? IncludeSpecificTopic { get; set; }
            public IncludeRelatedTopicsData? IncludeRelatedTopics { get; set; }
            public IncludeAllData? IncludeAll { get; set; }
            public IncludeTopicsOfNamespaceData? IncludeTopicsOfNamespace { get; set; }
            public IncludeTopicsOfTypeData? IncludeTopicsOfType { get; set; }
            public IncludeTopicsWithTagData? IncludeTopicsWithTag { get; set; }

            public enum RuleType
            {
                None = 0,
                IncludeSpecificTopic,
                IncludeRelatedTopics,
                IncludeAll,
                IncludeTopicsOfNamespace,
                IncludeTopicsOfType,
                IncludeTopicsWithTag
            }

            public class IncludeSpecificTopicData
            {
                public required Guid TopicGuid { get; set; }
            }

            public class IncludeRelatedTopicsData
            {
                public required int MaxDepth { get; set; }
            }

            public class IncludeTopicsOfNamespaceData
            {
                public required string Namespace { get; set; }
            }

            public class IncludeTopicsOfTypeData
            {
                public required Guid TopicTypeGuid { get; set; }
            }

            public class IncludeTopicsWithTagData
            {
                public required string HierarchyName { get; set; }
                public required string Tag { get; set; }
            }

            public class IncludeAllData
            {
            }
        }
    }
}
