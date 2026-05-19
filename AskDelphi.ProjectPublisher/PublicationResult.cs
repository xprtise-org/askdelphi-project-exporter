namespace AskDelphi.ProjectPublisher
{
    public class PublicationResult
    {
        public Guid Tenant { get; set; }

        public Guid Project { get; set; }

        public string BaseURL { get; set; } = "";

        public List<PublicationSettings.RuleConfiguration> ContentSet { get; set; } = [];

        public bool Success { get; set; } = false;

        public List<string> GeneratedFiles { get; internal set; } = [];

        public Exception? Exception { get; internal set; }
    }
}