# About the AIBot data model

## Table of contents
- [About the AIBot data model](#about-the-aibot-data-model)
  - [Table of contents](#table-of-contents)
  - [Introduction](#introduction)
  - [Accessing the repository contents](#accessing-the-repository-contents)
  - [The index.json model](#the-indexjson-model)
  - [Content JSON files](#content-json-files)
    - [The Relation model](#the-relation-model)
    - [Type-specific properties](#type-specific-properties)
      - [ActionModel](#actionmodel)
      - [BlobModel](#blobmodel)
      - [ConceptModel](#conceptmodel)
      - [ExampleModel](#examplemodel)
      - [ExternalContentModel](#externalcontentmodel)
      - [MenuModel](#menumodel)
      - [NuggetModel](#nuggetmodel)
      - [PersonModel](#personmodel)
      - [ProcessModel](#processmodel)
      - [SimpleTopicModel](#simpletopicmodel)
      - [TaskModel](#taskmodel)
      - [ToolModel](#toolmodel)
      - [CollectionModel](#collectionmodel)

## Introduction
The command line tool will populate a local folder with JSON files and resources as they are exported from the project.

Typically these will be uploaded to an Azure storage container. A SAS URI will be handed to the customer with the following configuration:
1. A policy is created that provides READ access (**not list**) on the container for a limited time
1. A SAS URI is created for the container based on that policy

A policy is used so the lease on the container can be extended without needing to share another URL with the customer.

## Accessing the repository contents

Typically when getting access to an AskDelphi export, you will get a URL that allows you to download a single file called "index.json" from some online storage location, for example: *https://storageoutputurlexample.blob.core.windows.net/your-project/index.json?sv=2023-01-03&si=strategyframe-de-read&sr=c&sig=REDACTED*

You can split this URI in two parts being the base URL: *https://storageoutputurlexample.blob.core.windows.net/your-project/* and 
the access key *?sv=2023-01-03&si=strategyframe-de-read&sr=c&sig=REDACTED*

You can access any file in the repository by creating an HTTP GET request for the base URL, followed by the path of the file and then append the signature to the end as a query string. So if you wanted to access the file '*images/ef17bd10-78.png*' from the repository, you'd create a URI *https://storageoutputurlexample.blob.core.windows.net/your-project/images/ef17bd10-78.png?sv=2023-01-03&si=strategyframe-de-read&sr=c&sig=REDACTED*  and issue a GET request for that.

## The index.json model

At the top of the repository you'll find a file called *index.json*. In thie file you will find some oinformation about the parameters that were used for generating the export. This is a JSON object containing the following properties:

| Property | Type | Contents |
| -------- | ---- | -------- | 
| BaseURL | URI | URL of the API server that was used to generate the export. |
| Project | Guid | Unique identifier of the project that was exported. | 
| Tenant | Guid | Unique identifier of the tenant that this project belongs to. | 
| ContentSet | RuleConfiguration | The content set definition that defined which top-level elements were to be exported. | 
| Success | Boolean | A true value indicates the export succeeded, a false value indicates failure. |
| GeneratedFiles | Path[] | Array of paths to Content JSON files, relative to this file, that contain the top-level objects that were exported. |
| Exception | Exception | JSON-serialized .NET exception, in case the export process failed with an error. |

So, basically using the ```GeneratedFiles``` property, tools can access all of the content that was directly part of the content set.

The tool will automatically export all top-level content as well as all content that can be reached via AskDelphi relations, but only the topics that are directly in the content set definition will be added at the top level.

## Content JSON files

There are many different typoes of content files, but they all represent AskDelphi topics and will all share the following basic structure:

| Property | Type | Contents |
| -------- | ---- | -------- | 
| Type (required) | String | Short name of the topic's type. Depending on the type additional properties are availlable on top of the six that are common for all content. |
| URL | URI| The URI that should be used to open this topic in the end-user's webbrowser. |
| Guid | Guid | The unique ID of the content element, typically the topic guid. |
| Title | String | The title as it appears in the topic list. |
| ShortDescription | String | The contents of the topic description in AskDelphi. |
| Tags | String[] | An array of the titles of all hierarchy nodes that this object ha sben tagged to across all hierarchies. |
| Hash | String | A SHA1 hash of the JSON object before the HAsh property is set. This cna be used to detect anyc hanges in this object when processing updates. If the hash changes, the object has changed. |
| RelatedContent | Relation[] | A list of relations to other contents with some metadata bout the relation between this object and the related topic. |

The following properties are available for all topic types that support thumbnails or key visuals:

| Property | Type | Contents |
| -------- | ---- | -------- | 
| ThumbnailFile | Path | Path of the file that contains the thumbnail image for this content, if any. |
| KeyVisualFile | Path | Path of the file that contains the key visual image, image map or video for this content, if any. |

### The Relation model

The structure of a Relation typed object as found in the RelatedContent property is as follows:

| Property | Type | Contents |
| -------- | ---- | -------- | 
| TargetFile | Path | Path of the file that contains the target topic's model. For each topic there will be esxactly one file generated, so if multipel object refer to the same target via relations, this file will be included only once. |
| TargetTitle | String  | The title of the target topic as it would appear in the topic list. |
| PyramidLevel | String | This indicated to which named group of relations the topic belongs. These names have a meaning and they were chosen when the project's content design was defined. If the pyramid level is empty that typically means that the relation is internal to AskDelphi and exists for technical reasons only. |
| IsChild | Boolean | If true this means that this relation was marked in the project's content design as an aggregate relation, i.e. the targeted content is considered part of the parent. |


### Type-specific properties

In this section the additional properties that are available for each of the model types are described. Which properties are availabel depends on the value of the *Type* property that all objects start with. When parsing the JSON it makes sense to first read the type, and then depending on the type decide which properties to support.

#### ActionModel

Action topics are the lowest in the process, task, action hierarchy; they are used to describe a single action in a process step. From a modelling perspective, these are content topics without a complex structure.

| Property | Type | Contents |
| -------- | ---- | -------- | 
| Body | HTML | Rich-text (html) body of the action topic. | 

#### BlobModel

Blob topics are used to model binary files in the project. Binary files are for example ZIP files, Office documents or PDF files.

| Property | Type | Contents |
| -------- | ---- | -------- | 
| ContentType | String | Mime type that describes the target's contents. | 
| AlternativeText | String | Alternative text for the content, if specified. | 
| AspectRatio | String | Indication of the content's aspect ratio, if relevant. | 
| BlobResourceFile | Path | Path to the resource file that's modeled by the blob topic. |

#### ConceptModel

A concept or supportking knowledge model is a model that is intended to describe background knowledge regarding a subject. The content is divided into multiple named sections.

| Property | Type | Contents |
| -------- | ---- | -------- | 
| Body | HTML | Rich-text (html) body of the topic. |
| Parts | ConceptStepModel[] | Ordered list of the sections that make up the total content. | 

The ConceptStepModel object is structrured as follows:

| Property | Type | Contents |
| -------- | ---- | -------- | 
| Title | String | Title of the section |
| ResourceFilename | Path | Path of an image file or video (optional) that best descreibes this section. | 
| Body | HTML | Rich-text (html) body of the section. |

#### ExampleModel

Example topics are used to describe examples, they are very much like actions otherwise.

| Property | Type | Contents |
| -------- | ---- | -------- | 
| Body | HTML | Rich-text (html) body of the action topic. | 

#### ExternalContentModel

External content topics are used to refer to externally hosted content by means of a URL. These topics can either model a reference to the other content by means of a URL that can be opened in the browser, or they can be marked as referrinfg to a downloadable file that's hosted outside the AskDelphi content repository. These have the following additional properties:

| Property | Type | Contents |
| -------- | ---- | -------- | 
| LinkURL | URI | URL that identifies the location of the external data. |
| LinkTarget | String | Either is undefined, null, 'newwindow' or 'currentwindow', indicating the preferred way of opening this link from a bowser. | 
| LinkType | String | Either 'link' if this is a hyperlink, or 'download' if the target is a file to be downloaded. If null, assume link. | 

#### MenuModel

Models an AskDelphi menu topic.

| Property | Type | Contents |
| -------- | ---- | -------- |
| Menu | MenuEditorData | Optional list of menu groups and top-level navigation items. | 

The MenuEditorData is as follows:

| Property | Type | Contents |
| -------- | ---- | -------- |
| MenuGroups | MenuGroup[] | Optional list of menu groups . | 
| AdditionalHeaderMenuItems | AdditionalHeaderMenuItem[] | Optional list of menu groups . | 

The MenuGroup structure is as follows:

| Property | Type | Contents |
| -------- | ---- | -------- |
| Name | string | Name of the group | 
| Items | MenuGroupTarget[] | Optional list of menu items for the group. | 

The AdditionalHeaderMenuItem structure is as follows:

| Property | Type | Contents |
| -------- | ---- | -------- |
| Icon | string | Font awesome icon to be used for the top-level item. | 
| Target | MenuGroupTarget | Single target topic for this item. | 

The MenuGroupTarget structure is as follows:

| Property | Type | Contents |
| -------- | ---- | -------- |
| Title | string | User-provided title for the menu entry. | 
| TargetId | string | Topic guid of the target topic. This is also present in the list of outgoing relations, where you'll also find the filename for this content. | 
| TargetName | string | Name of the target topic. | 

#### NuggetModel

Models a nugget of knowledge following the nugget datamodel.

| Property | Type | Contents |
| -------- | ---- | -------- |
| FullDescription | String | An extended description of the concept that's being modeled by this nugget. | 
| InstructionVideoFilename | Path | Path to an instruction video file. | 
| TipImageFilename | Path | Path to a tip image for this nugget. | 
| TipText | HTML | Rich-text description of the tip. |
| Steps | NuggetStep[] | Ordered lst of steps that make up the step-by-step instructions for completing the task. |

The NuggetStep model is as follows:

| Property | Type | Contents |
| -------- | ---- | -------- |
| Instructions | HTML | Written instruction for completing this step . | 
| Text | String | Written instruction for completing this step . | 
| ImageFilename | Path | Path of an image that's representative for this process-step. |

#### PersonModel

| Property | Type | Contents |
| -------- | ---- | -------- | 
| Body | HTML | Rich-text (html) body of the person's description. | 
| EMail | String | E-mail address of the person. | 
| ProfileURL | URI | Link to the person's profile page. | 

#### ProcessModel

A description of a top-level process, expect tasks as children.

| Property | Type | Contents |
| -------- | ---- | -------- | 
| Body | HTML | Rich-text (html) body of the process. | 

#### SimpleTopicModel

Used to describe any content that has a rich-text body.

| Property | Type | Contents |
| -------- | ---- | -------- | 
| Body | HTML | Rich-text (html) body for this simple topic. | 

#### TaskModel

Tasks are part of the process, they in trun have nuggets or actions as children.

| Property | Type | Contents |
| -------- | ---- | -------- | 
| Body | HTML | Rich-text (html) body for this task. | 

#### ToolModel

Tools have some descriptive text for the tool and as part of their relations they will provide a link to the actual tool.

| Property | Type | Contents |
| -------- | ---- | -------- | 
| Introduction | HTML | Rich-text (html) body introducting this tool. | 
| Details | HTML | Rich-text (html) detailed description of the tool. | 

#### CollectionModel

Collections are used to group items together in a way that's not hierarchical. They are used to group content that is related in some way, but not in a way that can be described by a parent-child relationship.
They can be used on homepages or be embedded in other content.

| Property | Type | Contents |
| -------- | ---- | -------- | 
| Items | CollectionItemModel[] | Ordered list of items that make up this collection. |

The CollectionItemModel model is as follows:

| Property | Type | Contents |
| -------- | ---- | -------- |
| Title | String | Title of the item. | 
| Body | HTML | Rich-text (html) body of the collection item. | 
| Target | CollectionItemTarget | The target topic of the item. |
| ButtonLabel | String | text to be displayed on the button that links to the target. |
| MediaFile | Path | Path of an image that's representative for this collection item. |

The CollectionItemTarget model is as follows:

| Property | Type | Contents |
| -------- | ---- | -------- | 
| TopicGuid | String | Unique identifier of the collection item's target topic. |
| Filename | String | Path of the file that contains the target topic's model. |


