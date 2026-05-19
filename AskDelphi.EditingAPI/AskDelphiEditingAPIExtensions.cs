using Microsoft.Extensions.DependencyInjection;

namespace AskDelphi.EditingAPI
{
    public static class AskDelphiEditingAPIExtensions
    {
        public static void AddAskDelphiEditingAPI(this IServiceCollection services)
        {
            services.AddTransient<IAskDelphiTopicClient, AskDelphiTopicClient>();
            services.AddTransient<IAskDelphiProjectClient, AskDelphiProjectClient>();
            services.AddTransient<IAskDelphiResourceClient, AskDelphiResourceClient>();
            services.AddTransient<IAskDelphiRelationsClient, AskDelphiRelationsClient>();
        }
    }
}
