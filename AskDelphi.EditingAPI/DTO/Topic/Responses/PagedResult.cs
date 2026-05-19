namespace AskDelphi.EditingAPI.DTO.Topic.Responses
{
    public class PagedResult<T> where T : class
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<T> Result { get; set; }
        public int TotalAvailable { get; set; }
    }
}
