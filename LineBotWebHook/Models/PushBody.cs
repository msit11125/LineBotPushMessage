using LineBotWebHook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace LineBotWebHook.Models
{
    public class PushBody
    {
        public string to { get; set; }
        public SendMessage[] messages { get; set; }
    }
}