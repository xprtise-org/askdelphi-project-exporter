using AskDelphi.ProjectPublisher;
using AskDelphi.JSONExport.TopicPublishers;
using Microsoft.Extensions.DependencyInjection;

namespace AskDelphi.JSONExport
{
    public static class PublisherExtensions
    {
        public static void AddTopicPublishers(this IServiceCollection services)
        {
            services.AddSingleton<ITopicPublisher, ActionTopicPublisher>();
            services.AddSingleton<ITopicPublisher, BlobTopicPublisher>();
            services.AddSingleton<ITopicPublisher, ConceptTopicPublisher>();
            services.AddSingleton<ITopicPublisher, CollectionTopicPublisher>();
            services.AddSingleton<ITopicPublisher, ExternalContentTopicPublisher>();
            services.AddSingleton<ITopicPublisher, ExampleTopicPublisher>();
            services.AddSingleton<ITopicPublisher, HomePageTopicPublisher>();
            services.AddSingleton<ITopicPublisher, ImolaProcessTopicPublisher>();
            services.AddSingleton<ITopicPublisher, MenuTopicPublisher>();
            services.AddSingleton<ITopicPublisher, NuggetTopicPublisher>();
            services.AddSingleton<ITopicPublisher, PersonTopicPublisher>();
            services.AddSingleton<ITopicPublisher, PortletTopicPublisher>();
            services.AddSingleton<ITopicPublisher, ProcessTopicPublisher>();
            services.AddSingleton<ITopicPublisher, SimpleTopicPublisher>();
            services.AddSingleton<ITopicPublisher, TaskTopicPublisher>();
            services.AddSingleton<ITopicPublisher, ToolTopicPublisher>();
        }
    }
}
