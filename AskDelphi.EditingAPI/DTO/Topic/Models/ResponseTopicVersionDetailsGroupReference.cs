namespace AskDelphi.EditingAPI.DTO.Topic.Models
{
    public class ResponseTopicVersionDetailsGroupReference
    {
        /// <summary>
        /// TopicRelationReference group key
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// TopicRelationReference group name
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Contains information about topic relations/references
        /// </summary>
        public IEnumerable<ResponseTopicVersionDetailsReference> References { get; set; }
    }
}
