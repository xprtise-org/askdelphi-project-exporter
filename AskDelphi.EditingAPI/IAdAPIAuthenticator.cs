namespace AskDelphi.EditingAPI
{
    public interface IAdAPIAuthenticator
    {
        Task<string> GetTokenAsync(AskDelphiAPIContext context);
    }
}