using AskDelphi.EditingAPI.DTO.Editors.ImageMap;
using AskDelphi.EditingAPI.DTO.Editors.Label;
using AskDelphi.EditingAPI.DTO.Editors.Learning;
using AskDelphi.EditingAPI.DTO.Editors.ListEditor;
using AskDelphi.EditingAPI.DTO.Editors.Menu;
using AskDelphi.EditingAPI.DTO.Editors.PublishSettings;
using AskDelphi.EditingAPI.DTO.Editors.ScoringProfile;

namespace AskDelphi.EditingAPI.DTO.Editors
{
    public class EditorValue
    {
        public string EditorFieldId { get; set; }
        public ListValueData List { get; set; }
        public RichTextValueData RichTextEditor { get; set; }
        public SelectOneValueData SelectOne { get; set; }
        public SingleTopicChooserValueData SingleTopic { get; set; }
        public StringValueData String { get; set; }
        public TextValueData Text { get; set; }
        public ToggleValueData Toggle { get; set; }
        public FileValueData File { get; set; }
        /// <summary>
        /// Value and thus data for an image map editor
        /// </summary>
        public ImageMapValueData ImageMap { get; set; }
        /// <summary>
        /// Collection of tree value data used primarily for hierarchy editing
        /// </summary>
        public List<TreeValueData> Tree { get; set; }

        /// <summary>
        /// Contains learning editor data
        /// </summary>
        public LearningEditorData Learning { get; set; }
        /// <summary>
        /// Contains script data
        /// </summary>
        public ScriptValueData Script { get; set; }


        /// <summary>
        /// Contains values for selected checkboxes
        /// </summary>
        public CheckboxMultiSelectValueData CheckboxMultiSelect { get; set; }

        /// <summary>
        /// Value data of label editor
        /// </summary>
        public LabelEditorValueData Label { get; set; }

        /// <summary>
        /// Value data for homepage tabs editor
        /// </summary>
        public HomepageTabsEditorData HomepageTabsEditorData { get; set; }

        /// <summary>
        /// Value of the scoring profile editor
        /// </summary>
        public ScoringProfileEditorData ScoringProfile { get; set; }

        /// <summary>
        /// Value of the topic publication settings editor
        /// </summary>
        public TopicPublicationSettingsEditorData TopicPublicationSettingsEditorData { get; set; }

        /// <summary>
        /// Value of the menu editor
        /// </summary>
        public MenuEditorData MenuEditorData { get; set; }
    }
}