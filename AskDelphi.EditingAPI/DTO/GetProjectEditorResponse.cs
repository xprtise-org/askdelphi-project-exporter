using AskDelphi.EditingAPI.DTO.Editors;

namespace AskDelphi.EditingAPI.DTO
{
    public class GetProjectEditorResponse
    {
        public IEnumerable<TopicTypeEditorDefinition> Editors { get; }
    }
}
