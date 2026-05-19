namespace AskDelphi.EditingAPI
{
    [Serializable]
    internal class EditingApiRestRequestFailedException : Exception
    {
        public EditingApiRestRequestFailedException()
        {
        }

        public EditingApiRestRequestFailedException(string message) : base(message)
        {
        }

        public EditingApiRestRequestFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}