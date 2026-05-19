
using static AskDelphi.ProjectPublisher.PublicationSettings;

namespace AskDelphi.ProjectPublisher
{
    public interface IPublicationSettings
    {
        Guid TenantGuid { get; }
        Guid ProjectGuid { get; }
        Guid AclGuid { get; }
        string WorkflowStageTitle { get; }
        List<RuleConfiguration> ContentSet { get; }
        string BaseURL { get; }
        string BasePath { get; set; }
    }
}