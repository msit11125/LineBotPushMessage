﻿using LineBotWebHook.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Hosting;
using System.Web.Http;

namespace LineBotWebHook.Api
{
    [RoutePrefix("line")]
    public class LineController : ApiController
    {
        [HttpPost]
        [Route] //http://{hostname}/line 
        public IHttpActionResult webhook([FromBody] LineWebhookModels data)
        {

            if (data == null || data.events == null) return BadRequest();

            try
            {
                foreach (Event e in data.events)
                {
                    if (e.type == EventType.join) //發生加入事件
                    {
                        string senderID = ""; // 紀錄 ID
                        switch (e.source.type)
                        {
                            case SourceType.user:
                                senderID = e.source.userId;
                                break;
                            case SourceType.room:
                                senderID = e.source.roomId;
                                break;
                            case SourceType.group:
                                senderID = e.source.groupId;
                                var PushService = new PushServiceFactory(senderID, "好棒棒 加入成功，大家今天都吃飽了嗎?");
                                var botReply = PushService.Create();
                                botReply.send();
                                //紀錄senderID
                                if (!System.IO.File.Exists(HostingEnvironment.MapPath("~/GroupID.txt")))
                                {
                                    System.IO.File.AppendAllText(HostingEnvironment.MapPath("~/GroupID.txt"), senderID);
                                }
                                break;
                        }

                        System.IO.File.AppendAllText(HostingEnvironment.MapPath("~/MyTest.txt"), "傳遞者ID " + senderID + ", 內容 " + e.message.text??"");
                    }
                    else if (e.type == EventType.message) //發生對話事件
                    {

                        var BotAnsService = new BotAnswerServiceFactory(e.replyToken, procMessage(e.message));
                        var botReply = BotAnsService.Create();
                        botReply.send();

                    }
                }
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(HostingEnvironment.MapPath("~/MyTest.txt")," | 發生錯誤 :"+ ex.ToString());
                return BadRequest();
            }



            return Ok("OK");
        }


        private List<SendMessage> procMessage(ReceiveMessage m)
        {
            var msgs = new List<SendMessage>();
            SendMessage sm = new SendMessage()
            {
                type = Enum.GetName(typeof(MessageType), m.type)
            };
            switch (m.type)
            {
                case MessageType.sticker:
                    sm.packageId = m.packageId;
                    sm.stickerId = m.stickerId;
                    break;
                case MessageType.text:
                    sm.text = m.text;
                    if(m.text.Contains("肥宅"))
                    {
                        sm.text = "你誤會了，我是指在座的各位都是肥宅。";
                    }
                    break;
                default:
                    sm.type = Enum.GetName(typeof(MessageType), MessageType.text);
                    sm.text = "很抱歉，我只是一隻回音機器肥宅，目前只能回覆基本貼圖與文字訊息喔！";
                    break;
            }
            msgs.Add(sm);
            return msgs;
        }
    }

    

}