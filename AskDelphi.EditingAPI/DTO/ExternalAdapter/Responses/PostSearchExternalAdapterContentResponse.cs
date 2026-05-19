using AskDelphi.EditingAPI.DTO.ExternalAdapter.Models;

namespace AskDelphi.EditingAPI.DTO.ExternalAdapter.Responses
{
    public class PostSearchExternalAdapterContentResponse
    {
        /// <summary>
        /// Topic total count, which matches search criteria
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// Continuation token
        /// </summary>
        public string ContinuationToken { get; set; }
        /// <summary>
        /// Topics collection
        /// </summary>
        public IEnumerable<ResponseExternalAdapterTopicDescriptor> Topics { get; set; }
    }
}
