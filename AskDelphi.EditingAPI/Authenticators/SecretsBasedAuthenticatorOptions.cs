namespace AskDelphi.EditingAPI.Authenticators
{
    public class SecretsBasedAuthenticatorOptions
    {
        public string Secret { get; init; }
        public string ImpersonationUPN { get; init; }
        public string ImpersonationFullName { get; init; }
        public string ImpersonationEmail { get; init; }
    }
}
