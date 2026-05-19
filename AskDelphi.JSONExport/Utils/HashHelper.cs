using System.Security.Cryptography;
using System.Text;

namespace AskDelphi.JSONExport.Utils
{
    public static class HashHelper
    {
        public static string Hash(string input) => Convert.ToHexString(SHA1.HashData(Encoding.UTF8.GetBytes(input)));

    }
}
