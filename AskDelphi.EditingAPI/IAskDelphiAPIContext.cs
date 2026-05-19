

namespace AskDelphi.EditingAPI
{
    public interface IAskDelphiAPIContext
    {
        string URL { get; }
        Guid TenantGuid { get; }
        Guid ProjectGuid { get; }
        Guid AclGuid { get; }
        IAdAPIAuthenticator Authenticator { get; }

        Task<string> GetToken();
    }
}