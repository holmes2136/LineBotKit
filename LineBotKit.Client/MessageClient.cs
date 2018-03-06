using LineBotKit.Common.Model;
using LineBotKit.Common.Model.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LineBotKit.WebAPI.Model;

namespace LineBotKit.Client
{
    public class MessageClient: ClientBase, IMessageClient
    {
        public MessageClient(string _ChannelAccessToken)
        {
            this.ChannelAccessToken = _ChannelAccessToken;
        }

        /// <summary>
        /// https://api.line.me/v2/bot/message/push
        /// </summary>
        /// <param name="ToUserID"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        public async Task<ResponseItem> PushMessage(PushMessageRequest message)
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Post, "bot/message/push", message);
            request.Authorization = this.ChannelAccessToken;
            return await ExecuteApiCallAsync<ResponseItem>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// https://api.line.me/v2/bot/message/multicast
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        public async Task<ResponseItem> MulticastAsync(MultiCastMessageRequest messages)
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Post, "bot/message/multicast", messages);
            request.Authorization = this.ChannelAccessToken;
            return await ExecuteApiCallAsync<ResponseItem>(request).ConfigureAwait(false);
        }


        /// <summary>
        /// https://api.line.me/v2/bot/message/reply
        /// </summary>
        /// <param name="ToUserID"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        public async Task<ResponseItem> ReplyMessage(ReplyMessageRequest message)
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Post, "bot/message/reply",message);
            request.Authorization = this.ChannelAccessToken;
            return await ExecuteApiCallAsync<ResponseItem>(request).ConfigureAwait(false);
        }
    }
}
