using AskDelphi.JSONExport;

namespace AskDelphi.ProjectPublisher
{
    public interface IPublicationFinalizer
    {
        Task Finalize(IAskdelphiPublisherContext context, PublicationResult publicationResult);
    }
}
