using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineSendCmd.Model
{
    public class PostData
    {
        public string to { get; set; }
        public Message[] messages { get; set; }
    }



    public enum MessageType { text , image , video , audio ,location , sticker , imagemap }

    public class Message
    {
        public string type { get; set; }
        public string text { get; set; }
    }
}
