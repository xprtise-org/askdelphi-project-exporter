using AskDelphi.ProjectPublisher;
using AskDelphi.JSONExport;
using AskDelphi.JSONExport.DTO;
using AskDelphi.JSONExport.Output;
using AskDelphi.EditingAPI;
using AskDelphi.EditingAPI.Authenticators;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestSharp;
using System.Text.Json;
using static AskDelphi.ProjectPublisher.PublicationSettings;
using adpublisher;

await Parser.Default.ParseArguments<Options>(args).WithParsedAsync((Func<Options, Task>)(async options =>
{
    // If a session code was specified, use that to initialize the auth JSON file, then exit.
    if (!string.IsNullOrWhiteSpace(options.SessionCode) && !string.IsNullOrWhiteSpace(options.AuthenticationDataFile))
    {
        RegistrationModel model = await GetSessionRegistrationFromPortalAsync(options.SessionCode);
        WriteAuthenticationData(options, model);
        return;
    }

    // Otherwise, initialize the kernel and perform the publication action
    options = InitializeOptions(options);

    if (!string.IsNullOrWhiteSpace(options.OutFolder)) Directory.CreateDirectory(options.OutFolder);

    HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
    builder.Services.AddLogging();
    builder.Services.AddAskDelphiEditingAPI();
    builder.Services.AddAskdelphiPublisherFramework(new PublicationSettings
    {
        BaseURL = options.BaseURL ?? "http://tempuri.org/url=not-set",
        BasePath = options.OutFolder ?? ".",
        TenantGuid = options.TenantGuid,
        ProjectGuid = options.ProjectGuid,
        AclGuid = options.ACLGuid,
        WorkflowStageTitle = options.WorkflowStageTitle ?? "Publish",
        ContentSet = options.ContentSet ?? [
            new () { Type = RuleConfiguration.RuleType.IncludeTopicsOfNamespace, IncludeTopicsOfNamespace = new() { Namespace = "http://tempuri.org/imola-skill-area" } }],
    });

    if (!string.IsNullOrWhiteSpace(options.SecretFile) && File.Exists(options.SecretFile))
    {
        builder.Services.AddSingleton<SecretsBasedAuthenticatorOptions>(JsonSerializer.Deserialize<SecretsBasedAuthenticatorOptions>(File.ReadAllText(options.SecretFile)) ?? new());
        builder.Services.AddSingleton<IAdAPIAuthenticator, SecretBasedAuthenticator>();
    }
    else if (!string.IsNullOrWhiteSpace(options.AuthenticationDataFile) && File.Exists(options.AuthenticationDataFile))
    {
        builder.Services.AddSingleton<BearerTokenAuthenticatorOptions>(JsonSerializer.Deserialize<BearerTokenAuthenticatorOptions>(File.ReadAllText(options.AuthenticationDataFile)) ?? new());
        builder.Services.AddSingleton<IAdAPIAuthenticator, BearerTokenAuthenticator>();
    }

    // Plug in the desired output filesystem support
    builder.Services.AddSingleton<IPublicationTargetFilesystem, LocalFolderStore>();

    // Plug in the topic publishers; these genarate the file output per topic    
    builder.Services.AddTopicPublishers();

    // Plug in publication finalization support
    builder.Services.AddTransient<IPublicationFinalizer, PublicationProcessFinalizer>();

    // Compose the environment
    using IHost host = builder.Build();

    // Create the operation context and start the publishing action
    IAskdelphiPublisherContext context = new AskdelphiPublisherContext
    {
        AclGuid = options.ACLGuid,
        ProjectGuid = options.ProjectGuid,
        TenantGuid = options.TenantGuid,
        URL = options.EditingAPIBaseUrl?.Trim('/') ?? "https://edit.api.askdelphi.com",
        Authenticator = host.Services.GetRequiredService<IAdAPIAuthenticator>(),
        ContentSet = options.ContentSet,
    };

    IAskDelphiProjectPublisher publisher = host.Services.GetRequiredService<IAskDelphiProjectPublisher>();
    PublicationResult result = await publisher.Publish(context);

    await host.StopAsync();
}));

static async Task<RegistrationModel> GetSessionRegistrationFromPortalAsync(string sessionCode)
{
    RestClientOptions portalClientOptions = new("https://portal.askdelphi.com")
    {
        ThrowOnAnyError = true,
    };
    RestClient portalClient = new(portalClientOptions);
    RestRequest portalRequest = new("api/session/registration");
    portalRequest.AddQueryParameter("sessionCode", sessionCode);
    RegistrationModel? response = await portalClient.GetAsync<RegistrationModel>(portalRequest);
    return response ?? new();
}

static void WriteAuthenticationData(Options options, RegistrationModel model)
{
    BearerTokenAuthenticatorOptions bta = new()
    {
        RefreshToken = model.RefreshToken,
        Token = model.AccessToken,
        TokenFilename = (Path.GetFullPath(options.AuthenticationDataFile ?? "")),
        URL = model.Url
    };
    File.WriteAllText(options.AuthenticationDataFile ?? "auth.json", JsonSerializer.Serialize(bta));
    Console.WriteLine($"Initialized {options.AuthenticationDataFile} using session-code {options.SessionCode}.");
}

static Options InitializeOptions(Options options)
{
    options.SessionCode = null;

    // If an options file was specified, use that instead of the commandline options.
    if (!string.IsNullOrWhiteSpace(options.OptionsFilename) && File.Exists(options.OptionsFilename))
    {
        Options? defaultOptions = JsonSerializer.Deserialize<Options>(File.ReadAllText(options.OptionsFilename));
        options = defaultOptions ?? options;
    }
    else if (string.IsNullOrWhiteSpace(options.OptionsFilename))
    {
        // If we did not read the options from a file, use this opportunity to write them to the file
        File.WriteAllText(options.OptionsFilename ?? "options.json", JsonSerializer.Serialize(options));
    }

    return options;
}