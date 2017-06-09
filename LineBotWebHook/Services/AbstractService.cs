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
    public abstract class AbstractService : IReplyService
    {
        
        protected WebRequest request; 

        protected readonly string _token = WebConfigurationManager.AppSettings["ChannelAccessToken"]; 


        /*
               --- send message to LINE ---
               return response data
        */
        public virtual string send()
        {
            string result = null;
            try
            {
                WebResponse response = request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return result;
        }
    }
}