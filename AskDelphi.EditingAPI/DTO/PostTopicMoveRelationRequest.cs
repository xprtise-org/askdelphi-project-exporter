namespace AskDelphi.EditingAPI.DTO
{
    /// <summary>
    /// Parameters for the request to re-order topic relations. Requests the source relation to be moved so it is at t
    /// </summary>
    public class PostTopicMoveRelationRequest
    {
        /// <summary>
        /// Source topic identifier.
        /// </summary>
        public Guid SourceTopicId { get; set; }
        /// <summary>
        /// Unique identifier of the relation.
        /// </summary>
        public Guid FromReferenceId { get; set; }
        /// <summary>
        /// Target index, where within the pyramid level should the relation end up.
        /// </summary>
        public int TargetIndex { get; set; }
    }
}
