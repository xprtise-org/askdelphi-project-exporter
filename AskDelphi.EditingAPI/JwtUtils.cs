using System.IdentityModel.Tokens.Jwt;

namespace AskDelphi.EditingAPI
{
    public static class JwtUtils
    {
        public static DateTime GetExpiryTimestamp(string accessToken)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(accessToken);
                var token = jsonToken as JwtSecurityToken;
                return token.ValidTo;
            }
            catch (Exception ex)
            {
                Console.Error.Write($"Error validating token: {ex.Message} ({ex.GetType().Name})");
                return DateTime.MinValue;
            }
        }
    }
}
