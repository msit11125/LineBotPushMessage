using LineBotWebHook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LineBotWebHook
{
    public class BotAnswerServiceFactory : IServiceFactory
    {

        private ReplyBody replyBody;
        public BotAnswerServiceFactory(string t, List<SendMessage> m)
        {
            if (replyBody == null)
            {
                replyBody = new ReplyBody()
                {
                    replyToken = t, 
                    messages = m
                };
            }
        }


        public IReplyService Create()
        {
            return new BotAnswerService(replyBody);
        }





    }
}