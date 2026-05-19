using AskDelphi.ProjectPublisher;
using CommandLine;

namespace adpublisher;

public class Options
{
    // Auth

    [Option('b', "auth-file", Required = false, Default = null,
        HelpText = "Use the token pair from this file for authentication purposes.")]
    public string? AuthenticationDataFile { get; set; }

    [Option('s', "secret-file", Required = false, Default = null,
        HelpText = "Use an API secret for authentication purposes.")]
    public string? SecretFile { get; set; }

    // Options

    [Option('f', "options-file", Required = false,
        HelpText = "Filename of the file containing the default values for all options. If the file does nopt exist, initialize it with the current options.")]
    public string? OptionsFilename { get; set; }

    //

    [Option('t', "tenantid", Required = false,
        HelpText = "The tenant guid for the tenant in whose context the operation is carried out. This can be obtained from the hosting environment configuration editor, or from AskDelphi support.")]
    public Guid TenantGuid { get; set; }

    [Option('a', "aclid", Required = false,
        HelpText = "Identifier of the ACL that grants editing access to the user for whom the session code was created. You can get this from the ACL editor for the AskDelphi project.")]
    public Guid ACLGuid { get; set; }

    [Option('g', "stage", Required = false,
        HelpText = "Title of the workflow stage that is published.")]
    public string? WorkflowStageTitle { get; set; }

    [Option('p', "projectid", Required = false,
        HelpText = "Identifies the project for which the tool needs to be run, copy this from the project properties view.")]
    public Guid ProjectGuid { get; set; }

    [Option('x', "api", Required = false,
        HelpText = "Full URL to the editing API server that is to be used, defaults to the production server, specify only when testing with other environments such as staging or test.",
        Default = "https://edit.api.askdelphi.com/")]
    public string? EditingAPIBaseUrl { get; set; }

    [Option('o', "out", Required = false, Default = null, HelpText = "Target folder, required")]
    public string? OutFolder { get; set; }

    [Option('c', "session-code", Required = false, Default = null, HelpText = "Session code for AskDelphi, requires --auth-file to be set alos, will initialize the auth-file from the session code and then terminate.")]
    public string? SessionCode { get; set; }

    [Option('u', "base-url", Required = false, Default = null, HelpText = "Base URL for the publication that can be used to accesss the exported content.")]
    public string? BaseURL { get; set; }

    [Option('h', "out-container-uri", Required = false, Default = null, HelpText = "SAS URI for the container where updated files must be uploaded.")]
    public string? OutContainerURI { get; set; }

    /// <summary>
    /// Only for JSON settings, allo wspecifying a content set.
    /// </summary>
    public List<PublicationSettings.RuleConfiguration>? ContentSet { get; set; }
}
