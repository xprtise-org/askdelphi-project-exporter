using AskDelphi.JSONExport;
using Microsoft.Extensions.Logging;

namespace AskDelphi.ProjectPublisher
{
    public class TopicPublisherFactory : ITopicPublisherFactory
    {
        private readonly ILogger<TopicPublisherFactory> logger;
        private readonly IEnumerable<ITopicPublisher> publishers;

        public TopicPublisherFactory(ILogger<TopicPublisherFactory> logger, IEnumerable<ITopicPublisher> publishers)
        {
            this.logger = logger;
            this.publishers = publishers;

            this.logger.LogTrace("TopicPublisherFactory initialized with {NumberOfPublishers} publisher(s)", publishers?.Count() ?? -1);
        }

        public ITopicPublisher? GetTopicPublisher(IAskdelphiPublisherContext context, string topicNamespace) => (publishers ?? []).FirstOrDefault(x => x.IsPublisherFor(context, topicNamespace));
    }
}
