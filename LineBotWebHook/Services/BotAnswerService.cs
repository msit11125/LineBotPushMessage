using LineBotWebHook.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;

namespace LineBotWebHook
{
    public class BotAnswerService : IReplyService
    {
        public const string API_URL = "https://api.line.me/v2/bot/message/reply";
        private WebRequest request;

        public BotAnswerService(ReplyBody body)
        {
            //設定Header
            request = WebRequest.Create(API_URL);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["Authorization"] = $"Bearer { WebConfigurationManager.AppSettings["ChannelAccessToken"] }";

            //開始傳送Json
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string data = JsonConvert.SerializeObject(body);
                streamWriter.Write(data);
                streamWriter.Flush();
            }

        }


        /*
               --- send message to LINE ---
               return response data
        */
        public virtual string send()
        {
            string result = null;
            try
            {
                WebResponse response = request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return result;
        }
    }
}