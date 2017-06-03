using LineBotWebHook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LineBotWebHook
{
    public class PushServiceFactory:AbstractReplyServiceFactory
    {
        private PushBody pushbody;

        public PushServiceFactory(string to,string msg)
        {
            pushbody = new PushBody()
            {
                to = to,
                messages = new[] {
                            new SendMessage() {
                            type = "text",
                            text = msg
                        }
                }
            };
        }
        
        public IReplyService Create()
        {
            return new PushService(pushbody);
        }
    }
}