namespace AskDelphi.EditingAPI.DTO
{

    public class PostTopicWorkflowReponse
    {
        public bool Status { get; set; }
        /// <summary>
        /// Unique id of the new topic version id
        /// </summary>
        public Guid? TopicVersionId { get; set; }
    }
}
