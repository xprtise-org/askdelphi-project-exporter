namespace AskDelphi.EditingAPI.DTO.Editors
{
    public class TopicPart
    {
        public string DefaultLabel { get; set; }
        public string DescriptionHTML { get; set; }
        public TopicPartFieldEditor[] Editors { get; set; }
        public string[] Keywords { get; set; }
        public string PartId { get; set; }
        /// <summary>
        /// Based on topic state and source of topic, indicates if topic part is readonly
        /// </summary>
        public bool IsReadOnly { get; set; }
    }
}