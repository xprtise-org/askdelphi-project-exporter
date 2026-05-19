namespace AskDelphi.EditingAPI.DTO.Topic.Models
{
    public class PagedQuery
    {
        /// <summary>
        /// The page number
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// The number of items to be returned per page
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Indicates number of records to skip before returning the result
        /// </summary>
        public int Skip => Math.Clamp(Page - 1, 0, int.MaxValue) * PageSize;
    }
}
