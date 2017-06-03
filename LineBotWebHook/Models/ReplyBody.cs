using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LineBotWebHook.Models
{
    public class ReplyBody
    {
        public string replyToken { get; set; }
        public List<SendMessage> messages { get; set; }
    }

    ////  ** Json模型 **

    //{
    //    "replyToken":"nHuyWiB7yP5Zw52FIkcQobQuGDXCTA",
    //    "messages":[
    //        {
    //            "type":"text",
    //            "text":"Hello, user"
    //        }
    //    ]
    //}

}