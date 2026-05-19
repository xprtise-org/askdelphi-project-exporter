using Microsoft.Extensions.DependencyInjection;

namespace AskDelphi.ProjectPublisher
{
    public static class AskdelphiPublisherFrameworkExtensions
    {
        public static void AddAskdelphiPublisherFramework(this IServiceCollection services, IPublicationSettings publicationSettings)
        {
            services.AddSingleton<IPublicationSettings>(publicationSettings);
            services.AddSingleton<ITopicPublisherFactory, TopicPublisherFactory>();
            services.AddSingleton<IContentSetBuilder, ContentSetBuilder>();
            services.AddTransient<IAskDelphiProjectPublisher, AskDelphiProjectPublisher>();
        }
    }
}
