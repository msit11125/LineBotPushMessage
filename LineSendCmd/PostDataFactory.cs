using LineSendCmd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineSendCmd
{

    /// <summary>
    /// PostData 簡單工廠
    /// </summary>
    public class PostDataFactory
    {

        public static PostData CreateTextPostData(string to, string s)
            => new PostData()
            {
                to = to,
                messages = new[] {
                    new Message() {
                    type = "text",
                    text = s
                }
                }
            };
    }
}
