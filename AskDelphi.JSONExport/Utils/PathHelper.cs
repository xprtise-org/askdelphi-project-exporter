using System.Text.RegularExpressions;

namespace AskDelphi.JSONExport.Utils
{
    public static class PathHelper
    {
        public static string MakeValidFileName(string name)
        {
            var invalidFileNameChars = new string(Path.GetInvalidFileNameChars());
            string invalidChars = Regex.Escape(invalidFileNameChars);
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return Regex.Replace(name, invalidRegStr, "_");
        }
    }
}
