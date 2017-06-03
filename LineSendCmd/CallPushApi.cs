using Newtonsoft.Json;
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
    public class CallPushApi
    {
        HttpClient client;
        Object _locker = new object();
        public CallPushApi()
        {
            lock (_locker)
            {
                if (client == null)
                    client = new HttpClient();
            }

        }

        /// <summary>
        /// 傳送訊息
        /// </summary>
        /// <param name="msg">傳遞訊息</param>
        /// <returns></returns>
        public async Task<HttpStatusCode> PushMessage(string msg)
        {
            try
            {
                var url = ConfigurationManager.AppSettings["PushWebApi"];
                //設定Header
                var content = new StringContent(JsonConvert.SerializeObject(msg), Encoding.UTF8, "application/json");

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
