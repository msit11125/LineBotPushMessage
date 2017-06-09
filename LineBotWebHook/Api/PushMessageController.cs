using LineBotWebHook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;

namespace LineBotWebHook.Api
{
    [RoutePrefix("PushMessage")]

    public class PushMessageController : ApiController
    {
        [HttpPost]
        [Route] //http://{hostname}/PushMessage 
        public IHttpActionResult Push([FromBody]FromPostBody body)
        {
            try
            {
                var PushService = new PushServiceFactory(body.senderID, body.message);
                IReplyService botReply = PushService.Create();
                botReply.send();
            }
            catch (Exception)
            {
                return BadRequest();
            }


            return Ok("OK");
        }
    }

    public class FromPostBody
    {
        public string senderID { get; set; }
        public string message { get; set; }
    }
}
