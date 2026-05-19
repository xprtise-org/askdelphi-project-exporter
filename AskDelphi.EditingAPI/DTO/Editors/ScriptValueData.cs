namespace AskDelphi.EditingAPI.DTO.Editors
{
    /// <summary>
    /// Script editor information
    /// </summary>
    public class ScriptValueData
    {
        /// <summary>
        /// Secret used to sign the script and thus generate signature
        /// </summary>
        public string Secret { get; set; }
        /// <summary>
        /// MD5 base 64 encoded value of the secret and script
        /// </summary>
        public string Signature { get; set; }
        /// <summary>
        /// Actual script
        /// </summary>
        public string Script { get; set; }
    }
}
