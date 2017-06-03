namespace LineBotWebHook.Models
{
    public enum SourceType { user , group , room}
    public class Source
    {
        public SourceType type { get; set; }
        public string userId { get; set; }
        public string groupId { get; set; }
        public string roomId { get; set; }
    }
}