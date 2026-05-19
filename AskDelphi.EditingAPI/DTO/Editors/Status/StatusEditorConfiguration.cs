namespace AskDelphi.EditingAPI.DTO.Editors.Status
{
    /// <summary>
    /// Configuration required for publication status editor
    /// </summary>
    public class StatusEditorConfiguration
    {
        /// <summary>
        /// True if the editor should display the publication status
        /// </summary>
        public bool IsPublicationStatusTableEditor { get; set; }

        /// <summary>
        /// True if the editor should display the incoming relations
        /// </summary>
        public bool IsIncomingRelationsTableEditor { get; set; }
    }
}
