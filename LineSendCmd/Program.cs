using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LineSendCmd
{
    class Program
    {

        static readonly string _token = "TLw4WeVS1t3rXo2qwbT0rRAw8HONf2rA2bH+bsw0DuN7xvHWg6iJXShhX0ZF/gSxllvgKrFr1REIJ8WJqibV/MFhllh65E89l/9iuZp5bpY2vEplj6azg581Cy9q8oqAUaJ3BTE4a7RYi7dGUh8HmgdB04t89/1O/w1cDnyilFU=";

        /// <summary>
        /// 程式進入點
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var t = ExcuteChatAsync(args[0], args[1]);
            t.Wait();
        }


        /// <summary>
        /// 非同步執行傳送訊息
        /// </summary>
        /// <param name="to">Channel Access Token</param>
        /// <param name="msg">傳遞的訊息</param>
        /// <returns></returns>
        static async Task ExcuteChatAsync(string to, string msg)
        {
            LineMessagingService _LineService = new LineMessagingService(_token);
            var status = await _LineService.PushMessage(to, msg);
        }


    }


}
