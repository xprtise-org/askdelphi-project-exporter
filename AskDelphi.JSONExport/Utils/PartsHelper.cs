using AskDelphi.EditingAPI.DTO;
using AskDelphi.EditingAPI.DTO.Editors;
using AskDelphi.EditingAPI.DTO.Editors.Menu;

namespace AskDelphi.JSONExport.Utils
{
    internal static class PartsHelper
    {
        public static SingleTopicChooserValueData? GetResourceTopic(APIResponse<GetTopicContentPartsResponse> getPartsResponse, string groupId, string partId, string editorId)
        {
            TopicPartFieldEditor? editor = FindEditor(getPartsResponse, groupId, partId, editorId);
            if (null == editor) return null;

            return editor.Value.SingleTopic;
        }

        public static FileValueData? GetResourceFile(APIResponse<GetTopicContentPartsResponse> getPartsResponse, string groupId, string partId, string editorId)
        {
            TopicPartFieldEditor? editor = FindEditor(getPartsResponse, groupId, partId, editorId);
            if (null == editor) return null;

            return editor.Value.File;
        }

        public static string? GetString(APIResponse<GetTopicContentPartsResponse> getPartsResponse, string groupId, string partId, string editorId)
        {
            TopicPartFieldEditor? editor = FindEditor(getPartsResponse, groupId, partId, editorId);
            if (null == editor) return null;
            return editor.Type switch
            {
                EditorType.RichText => editor.Value.RichTextEditor.Value,
                EditorType.String => editor.Value.String.Value,
                EditorType.Text => editor.Value.Text.Value,
                EditorType.SelectOne => editor.Value.SelectOne.Id,
                _ => null,
            };
        }

        public static MenuEditorData? GetMenu(APIResponse<GetTopicContentPartsResponse> getPartsResponse, string groupId, string partId, string editorId)
        {
            TopicPartFieldEditor? editor = FindEditor(getPartsResponse, groupId, partId, editorId);
            if (null == editor) return null;
            return editor.Type switch
            {
                EditorType.Menu => editor.Value.MenuEditorData,
                _ => null,
            };
        }

        public static IEnumerable<IEnumerable<(EditorValue editorValue, TopicPartFieldEditor editor)>>? GetList(APIResponse<GetTopicContentPartsResponse> getPartsResponse, string groupId, string partId, string editorId)
        {
            TopicPartFieldEditor? editor = FindEditor(getPartsResponse, groupId, partId, editorId);
            if (null == editor) return null;
            return (editor.Value?.List?.Values ?? []).Select(listItem =>
            {
                return listItem.List.Values.Select(partItem =>
                {
                    TopicPartFieldEditor editorDefinition = editor.TypeDependentConfigurationData.List.ItemConfiguration.Editors.FirstOrDefault(listItemTemplate => listItemTemplate.EditorFieldId == partItem.EditorFieldId) ?? new();
                    return (editorValue: partItem, editor: editorDefinition);
                });
            });
        }


        public static SingleTopicChooserValueData? GetFile(IEnumerable<(EditorValue editorValue, TopicPartFieldEditor editor)> source, string editorId)
        {
            (EditorValue editorValue, TopicPartFieldEditor editor)? editorTuple = source?.FirstOrDefault(x => x.editorValue.EditorFieldId == editorId);
            if (!editorTuple.HasValue) return null;

            return editorTuple.Value.editorValue.SingleTopic;
        }

        public static string? GetString(IEnumerable<(EditorValue editorValue, TopicPartFieldEditor editor)> source, string editorId)
        {
            (EditorValue editorValue, TopicPartFieldEditor editor)? editorTuple = source?.FirstOrDefault(x => x.editorValue.EditorFieldId == editorId);
            if (!editorTuple.HasValue) return null;

            var editor = editorTuple.Value.editorValue;
            return editorTuple.Value.editor.Type switch
            {
                EditorType.RichText => editor.RichTextEditor.Value,
                EditorType.String => editor.String.Value,
                EditorType.Text => editor.Text.Value,
                _ => null,
            };
        }

        public static SingleTopicChooserValueData? GetSingleTopicChooserValue(IEnumerable<(EditorValue editorValue, TopicPartFieldEditor editor)> source, string editorId)
        {
            (EditorValue editorValue, TopicPartFieldEditor editor)? editorTuple = source?.FirstOrDefault(x => x.editorValue.EditorFieldId == editorId);
            if (!editorTuple.HasValue) return null;
            if (editorTuple.Value.editor.Type != EditorType.SingleTopicChooser) return null;

            EditorValue singleTopicChooserEditor = editorTuple.Value.editorValue;
            if (null == singleTopicChooserEditor) return null;
            return singleTopicChooserEditor.SingleTopic;
        }

        private static TopicPartFieldEditor? FindEditor(APIResponse<GetTopicContentPartsResponse> getPartsResponse, string groupId, string partId, string editorId)
        {
            TopicPartGroup? partGroup = getPartsResponse?.Response?.TopicEditorData?.Groups?.FirstOrDefault(x => x.PartGroupId == groupId);
            TopicPart? part = partGroup?.Parts?.FirstOrDefault(x => x.PartId == partId);
            TopicPartFieldEditor? editor = part?.Editors?.FirstOrDefault(x => x.EditorFieldId == editorId);
            return editor;
        }

        internal static FileValueData? GetFileValueData(APIResponse<GetTopicContentPartsResponse> getPartsResponse, string groupId, string partId, string editorId)
        {
            TopicPartFieldEditor? editor = FindEditor(getPartsResponse, groupId, partId, editorId);
            if (null == editor) return null;

            return editor.Value.File;
        }
    }
}
