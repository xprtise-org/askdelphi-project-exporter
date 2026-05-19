namespace AskDelphi.EditingAPI.DTO
{
    public class GetContentDesignResponse
    {
        /// <summary>
        /// ID for the content design object.
        /// </summary>
        /// <remarks>
        /// Currently not populated by the GET project/**/contentdesign API.
        /// </remarks>
        public Guid Key { get; set; }

        /// <summary>
        /// Title for the content design. User-provided.
        /// </summary>
        /// <remarks>
        /// Currently not populated by the GET project/**/contentdesign API.
        /// </remarks>
        public string Title { get; set; }

        /// <summary>
        /// List of pyramid levels, ordered.
        /// </summary>
        public IEnumerable<PyramidLevel> PyramidLevels { get; set; }

        /// <summary>
        /// List of all available topic type groups, ordered.
        /// </summary>
        public IEnumerable<TopicTypeGroup> TopicTypeGroups { get; set; }

        /// <summary>
        /// List of all topic types, their supported relations and the pyramid level the relation is defined at.
        /// </summary>
        public IEnumerable<TopicType> TopicTypes { get; set; }

        /// <summary>
        /// Definition of a pyramid level.
        /// </summary>
        public class PyramidLevel
        {
            /// <summary>
            /// Unique identifier of the pyramid level. This is used to refer to the pyramid level in the content design.
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// Internal object ID.
            /// </summary>
            public System.Guid Key { get; set; }

            /// <summary>
            /// Display name for the pyramid level
            /// </summary>
            public string DisplayName { get; set; }

            /// <summary>
            /// True if the level is deleted.
            /// </summary>
            /// <remarks>
            /// Currently not populated by the GET project/**/contentdesign API.
            /// </remarks>
            public bool IsDeleted { get; set; }

            /// <summary>
            /// These define the mutual ordering between pyramid levels.
            /// </summary>
            public int SequenceNumber { get; set; }

            /// <summary>
            /// Default rendering for relations at this pyramid level, could be top, side or expert.
            /// </summary>
            /// <remarks>
            /// Currently not populated by the GET project/**/contentdesign API.
            /// </remarks>
            public string DefaultRendering { get; set; }
        }

        /// <summary>
        /// Definition of a topic type group, which really is nothing more than a named grouping of topic types, used 
        /// either to define possible targets for named relations of a certain type, or for defining lists of filters
        /// on the topic list. The purpose is encoded in the object.
        /// </summary>
        public class TopicTypeGroup
        {
            /// <summary>
            /// Unique identifier of the topic type group. This is used to refer to the object in the content design.
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// System-assigned key, used for database purposes mainly.
            /// </summary>
            public System.Guid Key { get; set; }

            /// <summary>
            /// User-provided name.
            /// </summary>
            public string DisplayName { get; set; }

            /// <summary>
            /// True if the group is supposed to be deleted.
            /// </summary>
            /// <remarks>
            /// Currently not populated by the GET project/**/contentdesign API.
            /// </remarks>
            public bool IsDeleted { get; set; }

            /// <summary>
            /// True if this is intended to be used as a filter on the topic list.
            /// </summary>
            public bool IsTopicListFilter { get; set; }

            /// <summary>
            /// Informative: describes the role of the topic type group in the total content design, usually just set to either none or internal.
            /// </summary>
            public string Role { get; set; }

            /// <summary>
            /// List of Titles of topic types in this group, ordered
            /// </summary>
            public IEnumerable<string> TopicTypeTitles { get; set; }
        }

        public class TopicType
        {
            /// <summary>
            /// Unique identifier of the topic type. This is used to refer to the object in the content design.
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// System-assigned key, used for database purposes mainly.
            /// </summary>
            public System.Guid Key { get; set; }

            /// <summary>
            /// User-provided name for this topic type, only this should be shown to the user.
            /// </summary>
            public string DisplayName { get; set; }

            /// <summary>
            /// True if the topic type is deleted.
            /// </summary>
            /// <remarks>
            /// Currently not populated by the GET project/**/contentdesign API.
            /// </remarks>
            public bool IsDeleted { get; set; }


            /// <summary>
            /// Must contain a namespace identifier that's supported by AskDelphi.
            /// </summary>
            public string Namespace { get; set; }

            /// <summary>
            /// The list of allowed outgoing types of relations for this topic type, plus a mapping to pyramid level.
            /// </summary>
            public IEnumerable<TopicTypeRelation> Relations { get; set; }

            /// <summary>
            /// Topics of this type should preferably be displayed as if they are defined at this pyramid level. This can be process, task or action.
            /// </summary>
            /// <remarks>
            /// Currently not populated by the GET project/**/contentdesign API.
            /// </remarks>
            public string PreferredLevel { get; set; }

            /// <summary>
            /// When a topic is displayed then the primary next level in the support pyramid is this. Complicated but essentially used to define
            /// the next level for Process is Task, and the next level for Task is Action.
            /// </summary>
            /// <remarks>
            /// Currently not populated by the GET project/**/contentdesign API.
            /// </remarks>
            public string NextPyramidLevelTitle { get; set; }

            /// <summary>
            /// Identifies all content at this level should be rendered in the default manner or in a flat page rendering mode. Is a hint for rendering and has no other functional value.
            /// </summary>
            /// <remarks>
            /// Currently not populated by the GET project/**/contentdesign API.
            /// </remarks>
            public string PreferredRendering { get; set; }
        }

        public class TopicTypeRelation
        {
            /// <summary>
            /// Unique identifier of the relation. This is used to refer to the object in the content design.
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// System-assigned key, used for database purposes mainly.
            /// </summary>
            public System.Guid Key { get; set; }

            /// <summary>
            /// User-provided name, if any.
            /// </summary>
            public string DisplayName { get; set; }

            /// <summary>
            /// True if the topic type is deleted.
            /// </summary>
            /// <remarks>
            /// Currently not populated by the GET project/**/contentdesign API.
            /// </remarks>
            public bool IsDeleted { get; set; }

            /// <summary>
            /// Indication if the relation is internal or not. If set to true, users can't create these relations in the side-panel
            /// and the relation need not be defined at a pyramid level.
            /// </summary>
            public bool IsInternal { get; set; }

            /// <summary>
            /// All non-internal relations need to be defined at a pyramid level, so: this is a "Task"-level relation to a "Nugget"
            /// </summary>
            public string PyramidLevelTitle { get; set; }

            /// <summary>
            /// The title of the topic type group that defines all topic types that are allowed at this level.
            /// </summary>
            public string TopicTypeGroupTitle { get; set; }

            /// <summary>
            /// Legacy: Use Tag for Tags, Default otherwise
            /// </summary>
            /// <remarks>
            /// Currently not populated by the GET project/**/contentdesign API.
            /// </remarks>
            public string Use { get; set; }

            /// <summary>
            /// Legacy: Use Tag for Tags, Default otherwise
            /// </summary>
            /// <remarks>
            /// Currently not populated by the GET project/**/contentdesign API.
            /// </remarks>
            public string View { get; set; }
        }
    }
}
