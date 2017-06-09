using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LineSendCmd
{
    public class PushMessageApi
    {
        //Singleton 貪婪單例模式
        public static HttpClient client = new HttpClient();
        public PushMessageApi(){}

        /// <summary>
        /// 傳送訊息
        /// </summary>
        /// <param name="msg">傳遞訊息</param>
        /// <returns></returns>
        public static async Task<HttpStatusCode> PushMessage(string senderID, string msg)
        {
            try
            {
                var url = ConfigurationManager.AppSettings["PushWebApi"];

                //傳送data
                JObject jo = new JObject();
                jo.Add("senderID", senderID);
                jo.Add("message", msg);

                //設定Header
                var content = new StringContent(JsonConvert.SerializeObject(jo), Encoding.UTF8, "application/json");

                var PostResult = await client.PostAsync(url, content);

                return PostResult.StatusCode;
            }
            catch (Exception)
            {
                return HttpStatusCode.BadRequest;
            }

        }

    }
}
