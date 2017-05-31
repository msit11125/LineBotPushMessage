using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LineSendCmd
{
    public class LineMessagingService
    {
        HttpClient client;
        Object _locker = new object();
        public LineMessagingService(string ChannelAccessToken)
        {
            lock (_locker)
            {
                if (client == null)
                    client = new HttpClient();
            }

            //設定Header
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {ChannelAccessToken}");
        }

        /// <summary>
        /// 傳送訊息
        /// </summary>
        /// <param name="id">傳遞人ID</param>
        /// <param name="s">傳遞訊息</param>
        /// <returns></returns>
        public async Task<HttpStatusCode> PushMessage(string id,string s)
        {
            try
            {
                var url = "https://api.line.me/v2/bot/message/push";
                var JsonStr = JsonConvert.SerializeObject(PostDataFactory.CreateTextPostData(id,s));
                var content = new StringContent(JsonStr, Encoding.UTF8, "application/json");

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
