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
    public class PushService:AbstractService
    {
        public const string API_URL = "https://api.line.me/v2/bot/message/push";

        public PushService(PushBody body)
        {
            //設定Header
            request = WebRequest.Create(API_URL);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["Authorization"] = $"Bearer { _token }";

            //開始傳送Json
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string data = JsonConvert.SerializeObject(body);
                streamWriter.Write(data);
                streamWriter.Flush();
            }

        }

        
    }
}