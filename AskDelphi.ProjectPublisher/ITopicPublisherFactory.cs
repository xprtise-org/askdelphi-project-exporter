using AskDelphi.JSONExport;

namespace AskDelphi.ProjectPublisher
{
    public interface ITopicPublisherFactory
    {
        /// <summary>
        /// Returns the topic publisher object that's suitable for publishingg topics with the specified namespace.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="topicNamespace"></param>
        /// <returns></returns>
        ITopicPublisher? GetTopicPublisher(IAskdelphiPublisherContext context, string topicNamespace);
    }
}