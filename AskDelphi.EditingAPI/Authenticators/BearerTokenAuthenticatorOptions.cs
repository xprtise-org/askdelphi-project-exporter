namespace AskDelphi.EditingAPI.Authenticators
{
    public class BearerTokenAuthenticatorOptions
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string TokenFilename { get; set; }
        public string URL { get; set; }
    }
}
