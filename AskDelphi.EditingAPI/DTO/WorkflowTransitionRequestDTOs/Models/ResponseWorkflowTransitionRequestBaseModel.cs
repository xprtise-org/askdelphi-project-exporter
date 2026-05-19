namespace AskDelphi.EditingAPI.DTO.WorkflowTransitionRequestDTOs.Models
{
    /// <summary>
    /// Base model of any workflow transition request model
    /// </summary>
    public class ResponseWorkflowTransitionRequestBaseModel
    {
        /// <summary>
        /// Unique id of the request
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Indicates if request is editable
        /// </summary>
        /// <remarks>
        /// Calculated based on <see cref="IsApproved"/> in which case <see cref="IsEditable"/> is always set to false.
        /// And based on the user requesting this model. When the user requesting this model is different from the user that created the request the <see cref="IsEditable"/> is set to false
        /// </remarks>
        public bool IsEditable { get; set; }
        /// <summary>
        /// Indicates if request is approved
        /// </summary>
        public bool IsApproved { get; set; }
        /// <summary>
        /// Title of the transition request
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Indicates if the transition is only available to admins
        /// </summary>
        public bool OnlyAvailableToProjectAdmins { get; set; }
    }
}
