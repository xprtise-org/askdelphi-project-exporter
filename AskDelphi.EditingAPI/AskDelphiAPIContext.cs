namespace AskDelphi.EditingAPI
{
    public class AskDelphiAPIContext : IAskDelphiAPIContext
    {
        public string URL { get; init; }
        public Guid TenantGuid { get; init; }
        public Guid ProjectGuid { get; init; }
        public Guid AclGuid { get; init; }
        public IAdAPIAuthenticator Authenticator { get; init; }

        public async Task<string> GetToken()
        {
            return await Authenticator.GetTokenAsync(this);
        }
    }
}
