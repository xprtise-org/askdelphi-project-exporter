namespace AskDelphi.EditingAPI.DTO.Topic.Requests
{
    /// <summary>
    /// Request object, containing secret and script, required to generate signature
    /// </summary>
    public class PostGenerateSignatureForScriptTopicRequest
    {
        /// <summary>
        /// Powershell script text
        /// </summary>
        public string Script { get; set; }
        /// <summary>
        /// Secret used to generate the signature
        /// </summary>
        public string Secret { get; set; }
    }
}
