namespace AskDelphi.EditingAPI.DTO
{
    public class APIResponse<T>
    {
        public bool Success { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public T Response { get; set; }
    }
}
