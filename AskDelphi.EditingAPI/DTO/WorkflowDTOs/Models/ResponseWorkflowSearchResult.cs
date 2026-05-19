namespace AskDelphi.EditingAPI.DTO.WorkflowDTOs.Models
{
    /// <summary>
    /// Contains information about a single workflow search result
    /// </summary>
    public class ResponseWorkflowSearchResult
    {
        /// <summary>
        /// Unique id of the workflow
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Name of the workflow
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Indicates the number of stages that this workflow has
        /// </summary>
        public int StageCount { get; set; }
        /// <summary>
        /// Indicates the names of the workflow stages, in sequence of the stages
        /// </summary>
        public List<string> StageNames { get; set; }

        /// <summary>
        /// Indicates if the workflow is enabled
        /// </summary>
        public bool Enabled { get; set; }
    }
}
