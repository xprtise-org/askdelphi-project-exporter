# Configuring the AI Bot Export tool via the command line

Given a project and a content set definition, publishes the content of that project to a format that can be efficiently
read by a machine.

## Authentication

You can either authenticate using an API key and an ACL, or you can authenticate using a session code. 

### Using session codes
A session code can be obtained from the AskDelphi publication by enabling the *Enable new Mobile user experience (experimental)* 
publication setting on the Mobile/General tab in the publication settings. After enabling this, select the *Support
mobile access using QR or access code* option. Having done this, the desktop publication should show a "QR Code" tab
on the side. Use this to obtain a session code, it's printed below the QR code.

*HINT:* You can create a special publication for creating session codes, as long as the publication is on the same hosting 
environment as the publication you wish to export, the obtained session code will be valid.

After obtaining the session code, run ```adpublisher --auth-file auth.json --session-code SESSION-CODE``` once, which will generate
```auth.json``` for you. You can keep using that file from now on, and just specify the ```--auth-file auth.json``` parameter.
Note that the file will be updated, so sharing or copying this file is discouraged. Instead have users create their own session 
code.

### Using an API key

If you have an API key, you can create a special file called ```secrets.json``` which should be in the following format:

```JSON
{
    "ImpersonationEmail": "info@example.com",
    "ImpersonationFullName": "Johnatan Doe",
    "ImpersonationUPN": "info@example.com",
    "Secret": "Purpose:SecretKey"
}
```

## Usage

To use the software, create a ```parameters.json``` file with the following structure (you can pass most parameters on the command-
line, but since the content set can't be provided this way it makes more sense to create a JSON file per project instead).

```JSON
{
    "TenantGuid": "{{AskDelphi Tenant Guid}}",
    "ACLGuid": "{{AskDelphi Authoring API ACL Guid}}",
    "ProjectGuid": "{{AskDelphi Project Guid}}",
    "WorkflowStageTitle": "{{Workflow Stage Title}}",
    "EditingAPIBaseUrl": "https://edit.api.askdelphi.com/",
    "AuthenticationDataFile": "/path/to/auth.json",
    "SecretFile": null,
    "OutFolder": "/path/to/output/folder",
    "BaseURL": "https://publication.example.com/en-US/Demo",
    "ContentSet": [
        { "Type": "IncludeTopicsOfNamespace", "IncludeTopicsOfNamespace": { "Namespace": "http://tempuri.org/imola-skill-area" } }
    ]
}
```

Run the software as follows:

```
adpublisher -f parameters.json
```

This will complete the publication of all content in the content set and all related content, and will write this in the output folder.

# Flow

So the flow to get from zero to a project export is the following:

1. Determine which project you are going to export and for which tenant
1. Ensure you have a user that has access to both the publication and the CMS V2 for this project
    1. Make sure that session codes are enabled on a publication for this project by enablying QR codes and the new mobile experience in the publication settings. This publication can be any publication, even one you specifically create for this purpose.
    1. Make sure that there is an ACL created in the CMS for the user who will perform the export giving them rights to access the content.
1. Make sure that you know the name of the workflow stage for production (you can look this up in the CMS V1 publication settings or in V2 in the workflow administration pages)
1. Log in with the exporting-user on the publication
1. Use the QR code tab to create a session code
1. Run the command ```adpublisher --auth-file MY-AUTH-FILE.json --session-code MY-SESSION-CODE``` once
1. Define the content set you need and create parameters.json
1. Run the command ```adpublisher -f parameters.json``` to create the export.

# Documentation for the parameters.json file

## TenantGuid, ProjectGuid, ACLGuid

Mandatory parameters that identify the tenant and project. The ACL used should be the ACL that gives the user for which the session code
was originally used read-access to the project data.

## WorkflowStageTitle

Mandatory title of a workflow stage. The content version that's published is the one that is in that workflow stage.

## EditingAPIBaseUrl

Only use a value different from ```https://edit.api.askdelphi.com/``` when specifically instructued to do so.

## AuthenticationDataFile

Name of the file that was created when a session code was processed.

## SecretFile

Name of the file containing your API key and secret if you have those.

## OutFolder

Target foilder where the output of the publication process is published to.

## ContentSet

JSON representation of a (simplified) content set. The publisher will primarily publish all content from this set, and all content that is
related to it, (whether that is part of the setr or not). This differs from the AskDelphi content sets where also content can be
excluded. This may change in the future.

### Rules:

Rules have a Type, which is one of ```IncludeSpecificTopic```, ```IncludeRelatedTopics```, ```IncludeAll```, ```IncludeTopicsOfNamespace```,
```IncludeTopicsOfType``` or ```IncludeTopicsWithTag```. Depending on the Type of rule, specific data is present in a property named after the rule.

The rules are executed in the order they are defined, and will modify the content set in the way indocated. You could for example start with an empty content set, include all topics with the namespace for homepage topics, include all topics with the namespace for menu topics, and then include related content. That way you would end up with a content set that mimics the default publication cotent set for askdelphi.

#### IncludeAll

Include all content from the project in the content set.

```JSON
{
  "Type": "IncludeAll"
}
```


#### IncludeSpecificTopic

Include one specific topic in the content set.

```JSON
{
  "Type": "IncludeSpecificTopic",
  "IncludeSpecificTopic": {
    "TopicGuid": "Guid of the topic to include"
  }
}
```

#### IncludeRelatedTopicsData

Include all content that can be reached via relations from the current content set also in the content set, you can specify a maximum recursion depth to limit this.

```JSON
{
  "Type": "IncludeRelatedTopics",
  "IncludeRelatedTopics": {
    "MaxDepth": number
  }
}
```

#### IncludeTopicsOfNamespace

Include all topics with a specific namespace. A namespace looks like http://tempuri.org/imola-xxx or http://tempuri.org/doppio-xxx and can be found in the content design of the project under topic types. Using namespaces may help re-use content set definitions over multiple projects because evven if the topic type is called 'Procezz' , the underlying namespace will still be http://tempuri.org/imola-skill-area

```JSON
{
  "Type": "IncludeTopicsOfNamespace",
  "IncludeTopicsOfNamespaceData": {
    "Namespace": "namespace of which all topics should be included"
  }
}
```

#### IncludeTopicsOfType

Include all topics with a specific topic type in the content set. The guid of a topic type can be found in the content design under topic types.

```JSON
{
  "Type": "IncludeTopicsOfType",
  "IncludeTopicsOfTypeData": {
    "TopicTypeGuid": "Guid from the content design for the topic type for which all content is included"
  }
}
```

#### IncludeTopicsWithTag

Include all topics that are tagged to a certain hierarchy node.

```JSON
{
  "Type": "IncludeTopicsWithTag",
  "IncludeTopicsWithTagData": {
    "HierarchyName": "NAme of the hierarchy topic"
    "Tag": "All content tagged to the tag with this name is included"
  }
}
```

