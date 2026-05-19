using AskDelphi.JSONExport;

namespace AskDelphi.ProjectPublisher
{
    public interface IAskDelphiProjectPublisher
    {
        Task<PublicationResult> Publish(IAskdelphiPublisherContext context);
    }
}