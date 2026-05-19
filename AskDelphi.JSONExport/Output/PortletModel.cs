using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AskDelphi.JSONExport.Output
{
    public class PortletModel : IModelWithBasicData, IModelWithRelatedContent
    {
        /// <summary>
        /// Returns the type of this object.
        /// </summary>
        public string Type => GetType().Name;
        /// <summary>
        /// The URL that can be used by an end-user to access the contents of this Collection in the context of the full publication.
        /// </summary>
        public string? URL { get; set; }
        /// <summary>
        /// A unique identifier for this content. Will remain constant over multiple exports.
        /// </summary>
        public string? Guid { get; set; }
        /// <summary>
        /// The title of the information Collection.
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// If set, a short plain-text description of the Collection.
        /// </summary>
        public string? ShortDescription { get; set; }
        /// <summary>
        /// If set, contains a key visual for the topic that can be used for various purposes.
        /// </summary>
        public List<string>? Tags { get; set; }
        /// <summary>
        /// Hash of the serialized content, without this hash.
        /// </summary>
        public string? Hash { get; set; }
        /// <summary>
        /// Content that's referred to from this topic.
        /// </summary>
        public List<RelatedContent> RelatedContent { get; set; } = [];
    }
}

