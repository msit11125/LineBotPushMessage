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
            var t = ExcuteChatAsync(args[0] /*senderID*/, args[1]/*Message*/);
            t.Wait();
        }


        /// <summary>
        /// 非同步執行傳送訊息
        /// </summary>
        /// <param name="senderID">傳送對象</param>
        /// <param name="msg">傳遞的訊息</param>
        /// <returns></returns>
        static async Task ExcuteChatAsync(string senderID , string msg)
        {
            var status = await PushMessageApi.PushMessage(senderID,msg);
  
            //Console.WriteLine(status ...........);
        }
    }


}
