# AskDelphi CMS Project Exporter

This tool allows you to export projects from the AskDelphi CMS using a CLI client.

Also included in the repository is an AI-generated WPF application that provides a user interface for exporting projects from the AskDelphi CMS.
It's AI-generated so it may not be the most user-friendly, but it should work for basic exporting needs when the CLI client is not an option.

## Usage sample using PowerShell

Example of a PowerShell script that generates an options file and uses an API key for authentication. The script writes a JSON
options file for the CLI client and then runs the client with that options file. Make sure to replace the values in the `$Options` 
with your actual data before running the script. An API key may be requested from XPrtise. Use that to create ```secrets.json``` as 
described in the comments in the script.

```powershell
$Options = @{
    # Guid of your tenant, you can find this in the URL in the CMS
    "TenantGuid" = "1a32fafd-d475-4afb-ac4a-065455a0ba8e"
    
    # Guid of your project, you can find this in the URL in the CMS
    "ProjectGuid" = "bddc1415-8d27-4297-af5c-7a0a504a1893"
    
    # Title of the workflow stage that should be exported, you can find this in the 
    # CMS in the workflow configuration
    "WorkflowStageTitle" = "Draft"
    
    # Guid of your tenant, you can find this in the URL in the CMS, this file has 
    # the keys ImpersonationEmail, ImpersonationFullName, ImpersonationUPN and Secret
    # where the secret is your API Key. The ImpersonationEmail, ImpersonationFullName,
    # ImpersonationUPN should match the values provided when the API key was created 
    # in the CMS.
    "SecretFile" = "$PSScriptRoot\secrets.json"
    
    # This is where the genarated index.json and associated files are are written
    "OutFolder" = "$PSScriptRoot\Export-Output"

    # This should be your publication URL, this is used in the output to 
    # construct a link to the original content, which in turn can be presented
    # as a source in the output.
    "BaseURL" = "https://publication.example.com"

    # Name of this file. The file will actually be generated in the scripts folder.
    "OptionsFilename" = "Sample-Options.json"
    "OptionsSaveFilename"  = "Sample-Options-Saved.json"

    # Only needed when performing session-code based authentication. The flow is
    # different from API key authentication and requires you to first obtain a
    # session code, which is then used to authenticate and export the project. 
    # This is an alternative to using an API key and is preferred in most cases
    # for one-off activities.
    "SessionCode" = ""
    "AuthenticationDataFile" = ""

    # Guid of an ACL that grants the user with the claims provided for the API
    # key access to the content.
    "ACLGuid" =  "a1403b29-ebe6-4b4d-a0e4-b3365386bcc0"

    # Te URL of the editing API, there should never be a reason to change this
    "EditingAPIBaseUrl" =  "https://edit.api.askdelphi.com" 

    # Undocumented, leave empty
    "OutContainerURI" = ""

    # This section defines what content is included in the export. In this case, 
    # all topics in the "http://tempuri.org/imola-skill-area" namespace are included. 
    # Contrary to publication content sets, this set always ends with an implicit
    # "And include all related content" rule. The types of rules are documented elsewhere.
    "ContentSet" = @(
        @{ 
            "Type" = "IncludeTopicsOfNamespace"
            "IncludeTopicsOfNamespace" = @{ 
                "Namespace" = "http://tempuri.org/imola-skill-area" 
            }
        }
    )
}

Remove-Item -Recurse -Force -ErrorAction Ignore -Path $Options.OutFolder | Out-Null
New-Item -ItemType Directory -Path $Options.OutFolder | Out-Null

$Options | ConvertTo-Json -Depth 10 | Out-File -FilePath "$PSScriptRoot\$($Options.OptionsFilename)" -Encoding UTF8
Write-Host "Options saved to $($Options.OptionsFilename)"

Push-Location "D:\tools\AdToJSON\bin"
try {
    .\AdToJSON.exe --options-file "$PSScriptRoot\$($Options.OptionsFilename)"
}
catch {
    Write-Error "An error occurred while running AdToJSON: $_"
}
finally {
    Pop-Location
}
Write-Host "Done exporting $($Options.OptionsFilename) to $($Options.OutFolder)"
```

A typical ```secrets.json``` file for API key authentication would look like this:

```json
{
    "ImpersonationEmail": "support@xprtise.com",
    "ImpersonationFullName": "support@xprtise.com",
    "ImpersonationUPN": "support@xprtise.com",
    "Secret": "SAMPLE0001:d3b6a2a51658e11762df12e8"
}
```

## Session-code based authentication

In case session-code based authentication is used, first a session code must be obtained form the publication 
(enable mobile mode with QR code login to obtain a session code). Then the tool is run once in authentication mode
to generate the "AuthenticationDataFile", after which the tool is ready for use in export mode.

More details about that flow can be found in [command-line.md](documentation/command-line.md).

# Documentation

More information about how to use the tool can be found in [command-line.md](documentation/command-line.md). Read 
[exported-data.md](documentation/exported-data.md) in the documentation folder for more information about the 
output format.
