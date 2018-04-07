using LineBotKit.Client;
using LineBotKit.Common.Model;
using LineBotKit.Common.Model.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LineBotKit.Simulator.Controllers
{
    /// <summary>
    /// Messagin API
    /// </summary>
    [RoutePrefix("api/Messaging")]
    public class MessagingController : ApiController
    {
        /// <summary>
        /// Send text message
        /// </summary>
        /// <param name="to"></param>
        /// <param name="message"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [ResponseType(typeof(ResponseItem)),Route("TextMessage"), HttpPost]
        public async Task<ResponseItem> PushTextMessage(string to, string message, string token)
        {
            ILineClientManager lineManager = new LineClientManager(token);
            return await lineManager.PushTextMessage(to, message);
        }

        /// <summary>
        /// Send image message
        /// </summary>
        /// <param name="to"></param>
        /// <param name="imageContentUrl"></param>
        /// <param name="imagePreviewUrl"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [Route("ImageMessage"), HttpPost]
        public async Task<ResponseItem> PushImageMessage(string to, string imageContentUrl, string imagePreviewUrl, string token)
        {
            ILineClientManager lineManager = new LineClientManager(token);
            return await lineManager.PushImageMessage(to, imageContentUrl, imagePreviewUrl);
        }

        /// <summary>
        /// Send sticker message
        /// </summary>
        /// <param name="to"></param>
        /// <param name="packageId"></param>
        /// <param name="stickerId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [Route("StickerMessage"), HttpPost]
        public async Task<ResponseItem> PushStickerMessage(string to, int packageId, int stickerId, string token)
        {
            ILineClientManager lineManager = new LineClientManager(token);
            return await lineManager.PushStickerMessage(to, packageId, stickerId);
        }
    }
}
