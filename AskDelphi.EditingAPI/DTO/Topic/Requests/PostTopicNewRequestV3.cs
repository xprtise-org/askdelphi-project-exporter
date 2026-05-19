namespace AskDelphi.EditingAPI.DTO.Topic.Requests
{
    public class PostTopicNewRequestV3
    {
        /// <summary>
        /// When not specified a new topic will be created with a new guid
        /// </summary>
        public Guid? TopicId { get; set; }
        /// <summary>Title of the topic </summary>
        public string TopicTitle { get; set; }
        /// <summary>Topic type of the topic </summary>
        public Guid TopicTypeId { get; set; }
        /// <summary>Parent topic unique identifier, once set means this topic to create is a relation to this parent topic</summary>
        public Guid? ParentTopicId { get; set; }
        /// <summary> Relation type identifier</summary>
        public Guid? ParentTopicRelationTypeId { get; set; }
        /// <summary>Publication unique identifier, that this topic belongs to</summary>
        public Guid? PublicationId { get; set; }
        /// <summary>Identifies whether to copy the tags relations from the parent topic</summary>
        public bool? CopyParentTags { get; set; }
    }
}
