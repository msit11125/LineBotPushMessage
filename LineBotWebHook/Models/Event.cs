using System.Collections.Generic;

namespace LineBotWebHook.Models
{
    public enum EventType { message, follow, unfollow, join, leave, postback, beacon }


    /// <summary>
    /// 依Model格式，Mapping to Json
    /// </summary>
    public class LineWebhookModels
    {
        public List<Event> events { get; set; }
    }


    public class Event
    {
        public EventType type { get; set; }
        public string timestamp { get; set; }
        public Source source { get; set; }
        public string replyToken { get; set; }
        public ReceiveMessage message { get; set; }
    }


    ////  ** Json模型 **

    //{
    //  "events": [
    //    {
    //      "replyToken": "nHuyWiB7yP5Zw52FIkcQobQuGDXCTA",
    //      "type": "message",
    //      "timestamp": 1462629479859,
    //      "source": {
    //        "type": "user",
    //        "userId": "U206d25c2ea6bd87c17655609a1c37cb8"
    //      },
    //      "message": {
    //        "id": "325708",
    //        "type": "text",
    //        "text": "Hello, world"
    //      }
    //    },
    //    {
    //      "replyToken": "nHuyWiB7yP5Zw52FIkcQobQuGDXCTA",
    //      "type": "follow",
    //      "timestamp": 1462629479859,
    //      "source": {
    //        "type": "user",
    //        "userId": "U206d25c2ea6bd87c17655609a1c37cb8"
    //      }
    //    }
    //  ]
    //}

}