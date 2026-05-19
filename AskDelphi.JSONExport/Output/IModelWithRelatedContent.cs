
namespace AskDelphi.JSONExport.Output
{
    public interface IModelWithRelatedContent
    {
        List<RelatedContent> RelatedContent { get; set; }
    }
}