namespace AskDelphi.EditingAPI.DTO.Editors
{
    public class TopicPartGroup
    {
        public string DefaultLabel { get; set; }
        public string DescriptionHTML { get; set; }
        public string Icon { get; set; }
        public string[] Keywords { get; set; }
        public string PartGroupId { get; set; }
        public TopicPart[] Parts { get; set; }
    }
}