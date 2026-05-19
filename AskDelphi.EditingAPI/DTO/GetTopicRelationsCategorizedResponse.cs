using AskDelphi.EditingAPI.DTO.Shared;

namespace AskDelphi.EditingAPI.DTO
{
    /// <summary>
    /// Contains all pyramid-levels at which relations can be made with their allowed relations. Also contains all current outgoing relations for the topic.
    /// </summary>
    public class GetTopicRelationsCategorizedResponse
    {
        /// <summary>
        /// Relations and allowed relations for a single pyramid level.
        /// </summary>
        public class TopicPyramidLevel
        {
            /// <summary>
            /// ID of the pyramid level.
            /// </summary>
            public Guid PyramidLevelId { get; set; }
            /// <summary>
            /// Title of the pyramid level/
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// Sequence number (for sorting)
            /// </summary>
            public int SequenceNumber { get; set; }
            /// <summary>
            /// List of potential relation types for relations that can be created from this topic at this level.
            /// </summary>
            public List<TopicAllowedRelation> AllowedRelations { get; set; }
            /// <summary>
            /// List of all current relations for the pyramid level.
            /// </summary>
            public List<TopicRelationDefinition> Relations { get; set; }
        }

        /// <summary>
        /// The list  of pyramid levels with their current and potential relations.
        /// </summary>
        public List<TopicPyramidLevel> PyramidLevels { get; set; }

        /// <summary>
        /// The list of non-pyramid level relations that currently exist.
        /// </summary>
        public List<TopicRelationDefinition> NonPyramidRelations { get; set; }
    }
}
