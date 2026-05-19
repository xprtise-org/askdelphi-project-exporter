namespace AskDelphi.EditingAPI.DTO.Topic.Responses
{
    /// <summary>
    /// Response object containing the signature
    /// </summary>
    public class PostGenerateSignatureForScriptTopicResponse
    {
        /// <summary>
        /// Md5 signature in base64 format
        /// </summary>
        public string Signature { get; set; }
    }
}
