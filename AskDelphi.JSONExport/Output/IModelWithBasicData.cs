
namespace AskDelphi.JSONExport.Output
{
    public interface IModelWithBasicData
    {
        string Type { get; }
        string? URL { get; set; }
        string? Guid { get; set; }
        string? Title { get; set; }
        string? ShortDescription { get; set; }
        List<string>? Tags { get; set; }
        string? Hash { get; set; }
    }
}