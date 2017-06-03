using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LineSendCmd
{
    class Program
    {


        /// <summary>
        /// 程式進入點
        /// </summary>
        /// <param name="args">傳送的訊息</param>
        static void Main(string[] args)
        {
            var t = ExcuteChatAsync(args[0]);
            t.Wait();
        }


        /// <summary>
        /// 非同步執行傳送訊息
        /// </summary>
        /// <param name="msg">傳遞的訊息</param>
        /// <returns></returns>
        static async Task ExcuteChatAsync(string msg)
        {
            CallPushApi _Push = new CallPushApi();
            var status = await _Push.PushMessage(msg);

            //Console.WriteLine(status ...........);
        }


    }


}
