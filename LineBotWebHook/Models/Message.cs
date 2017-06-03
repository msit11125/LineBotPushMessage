namespace LineBotWebHook.Models
{
    public enum MessageType { text, image, video, audio, location, sticker }
    public abstract class Message<T>
    {
        public string id { get; set; }
        public T type { get; set; }
        public string text { get; set; }
        public string title { get; set; }
        public string address { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public string packageId { get; set; }
        public string stickerId { get; set; }
    }

    //接收模型
    public class ReceiveMessage : Message<MessageType> { }

    //送出模型
    public class SendMessage : Message<string> { }
}