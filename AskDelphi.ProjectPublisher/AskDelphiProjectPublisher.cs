using AskDelphi.JSONExport;
using AskDelphi.EditingAPI;
using AskDelphi.EditingAPI.DTO.Project;
using AskDelphi.EditingAPI.DTO.Topic.Models;
using Microsoft.Extensions.Logging;

namespace AskDelphi.ProjectPublisher
{
    public class AskDelphiProjectPublisher(
        ILogger<AskDelphiProjectPublisher> logger,
        IContentSetBuilder contentSetBuilder,
        ITopicPublisherFactory topicPublisherFactory,
        IPublicationFinalizer publicationFinalizer,
        IAskDelphiProjectClient askDelphiProjectClient
            ) : IAskDelphiProjectPublisher
    {
        private readonly ILogger<AskDelphiProjectPublisher> logger = logger;
        private readonly IContentSetBuilder contentSetBuilder = contentSetBuilder;
        private readonly ITopicPublisherFactory topicPublisherFactory = topicPublisherFactory;
        private readonly IPublicationFinalizer publicationFinalizer = publicationFinalizer;
        private readonly IAskDelphiProjectClient askDelphiProjectClient = askDelphiProjectClient;

        public async Task<PublicationResult> Publish(IAskdelphiPublisherContext context)
        {
            PublicationResult publicationResult = new();

            logger.LogInformation($"Starting publication...");
            try
            {
                context.ContentDesign = (await askDelphiProjectClient.GetContentDesign(context)).Response;
                context.TopicPublisherFactory = topicPublisherFactory;

                List<(TopicListEntryIdentifier topicListEntry, ResponseTopicVersionHistoryTableModel version)> contentSet = await contentSetBuilder.BuildContentSet(context);

                foreach ((TopicListEntryIdentifier topicListEntry, ResponseTopicVersionHistoryTableModel version) in contentSet)
                {
                    try
                    {
                        ITopicPublisher? topicPublisher = topicPublisherFactory.GetTopicPublisher(context, topicListEntry.TopicTypeNamespace);
                        if (null == topicPublisher)
                        {
                            logger.LogWarning("There is no topic publisher for the {TopicTypeNamespace} namespace. Skipping topic {TopicGuid}.", topicListEntry.TopicTypeNamespace, topicListEntry.TopicGuid);
                            continue;
                        }

                        await PublishContentSetElement(context, publicationResult, topicListEntry, version, topicPublisher);
                        publicationResult.Success = true;
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Error publishing topic {TopicGuid} ({Title}) with namespace {TopicTypeNamespace}", topicListEntry.TopicGuid, topicListEntry.Title, topicListEntry.TopicTypeNamespace);
                    }
                }
                await publicationFinalizer.Finalize(context, publicationResult);
            }
            catch (Exception error)
            {
                logger.LogError(error, "Publication failed with error: {Name}: {Message}", error.GetType().Name, error.Message);

                publicationResult.Success = false;
                publicationResult.Exception = error;
                await publicationFinalizer.Finalize(context, publicationResult);
            }
            finally
            {
                logger.LogInformation($"Finished publication.");
            }
            return publicationResult;
        }

        private static async Task PublishContentSetElement(IAskdelphiPublisherContext context, PublicationResult publicationResult, TopicListEntryIdentifier topicListEntry, ResponseTopicVersionHistoryTableModel version, ITopicPublisher topicPublisher)
        {
            string? filename;
            Guid topicGuid = topicListEntry.TopicGuid;
            if (!context.PublishedTopics.TryGetValue(topicGuid, out _))
            {
                filename = await topicPublisher.PublishTopic(context, topicListEntry, version);
                context.PublishedTopics[topicGuid] = filename;
                if (null != filename)
                {
                    publicationResult.GeneratedFiles.Add(filename);
                }
            }
        }
    }
}
