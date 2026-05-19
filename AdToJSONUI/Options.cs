using AskDelphi.ProjectPublisher;

namespace AdPublisherUI;

public class Options
{
    // Auth

    public string? AuthenticationDataFile { get; set; }

    public string? SecretFile { get; set; }

    // Options

    public string? OptionsFilename { get; set; }

    //

    public Guid TenantGuid { get; set; }

    public Guid ACLGuid { get; set; }

    public string? WorkflowStageTitle { get; set; }

    public Guid ProjectGuid { get; set; }

    public string? EditingAPIBaseUrl { get; set; }

    public string? OutFolder { get; set; }

    public string? SessionCode { get; set; }

    public string? BaseURL { get; set; }

    public string? OutContainerURI { get; set; }

    /// <summary>
    /// Only for JSON settings, allo wspecifying a content set.
    /// </summary>
    public List<PublicationSettings.RuleConfiguration>? ContentSet { get; set; }
}
