using AskDelphi.EditingAPI.DTO.Editors.ImageMap;
using AskDelphi.EditingAPI.DTO.Editors.Label;
using AskDelphi.EditingAPI.DTO.Editors.Learning;
using AskDelphi.EditingAPI.DTO.Editors.ListEditor;
using AskDelphi.EditingAPI.DTO.Editors.Menu;
using AskDelphi.EditingAPI.DTO.Editors.PublishSettings;
using AskDelphi.EditingAPI.DTO.Editors.ScoringProfile;
using AskDelphi.EditingAPI.DTO.Editors.Status;

namespace AskDelphi.EditingAPI.DTO.Editors
{
    public class TypeDependentConfiguration
    {
        public ListConfiguration List { get; set; }
        public RichTextEditorConfiguration RichTextEditor { get; set; }
        public SelectOneConfiguration SelectOne { get; set; }
        public SingleTopicChooserConfiguration SingleTopic { get; set; }
        public StringConfiguration String { get; set; }
        public TextConfiguration Text { get; set; }
        public ToggleConfiguration Toggle { get; set; }
        public FileConfiguration File { get; set; }
        /// <summary>
        /// Contains configuration for the tree/hierarchy editor
        /// </summary>
        public TreeConfiguration Tree { get; set; }
        /// <summary>
        /// Contains configuration for the image map editor
        /// </summary>
        public ImageMapConfiguration ImageMap { get; set; }
        /// <summary>
        /// Learning editor configuration
        /// </summary>
        public LearningConfiguration Learning { get; set; }

        /// <summary>
        /// Contains configuration for script editor
        /// </summary>
        public ScriptEditorConfiguration Script { get; set; }

        /// <summary>
        /// Contains configuration for checkbox multi select editor
        /// </summary>
        public CheckboxMultiSelectConfiguration CheckboxMultiSelectConfiguration { get; set; }

        /// <summary>
        /// Configuration for label editor
        /// </summary>
        public LabelEditorConfiguration LabelConfiguration { get; set; }

        /// <summary>
        /// Configuration for homepage tabs editor
        /// </summary>
        public HomepageTabsConfiguration HomepageTabsConfiguration { get; set; }

        /// <summary>
        /// Configuration for scoring profile editor
        /// </summary>
        public ScoringProfileConfiguration ScoringProfileConfiguration { get; set; }

        /// <summary>
        /// Configration for the publication status editor
        /// </summary>
        public StatusEditorConfiguration StatusEditorConfiguration { get; set; }

        /// <summary>
        /// Configuration for the publish settings editor
        /// </summary>
        public TopicPublicationSettingsEditorConfiguration TopicPublicationSettingsEditorConfiguration { get; set; }

        /// <summary>
        /// Configuration for the menu editor
        /// </summary>
        public MenuEditorConfiguration MenuEditorConfiguration { get; set; }
    }
}