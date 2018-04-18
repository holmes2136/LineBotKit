using LineBotKit.Client.Request;
using LineBotKit.Client.Response;
using LinetBotKit.Common.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public class MessageClient: Request.LineClientBase, IMessageClient
    {

        public MessageClient(string channelAccessToken):base(channelAccessToken)
        {

        }

        /// <summary>
        /// Send message
        /// </summary>
        /// <param name="pushMessageRequest"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> PushMessage(PushMessageRequest pushMessageRequest)
        {
            if (pushMessageRequest == null)
            {
                throw new ArgumentNullException(nameof(PushMessageRequest));
            }

            var request = new LinePostRequest<ResponseItem>(this, "bot/message/push");

            return await request.Execute(pushMessageRequest);
        }

        /// <summary>
        /// Reply message
        /// </summary>
        /// <param name="replyMessageRequest"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> ReplyMessage(ReplyMessageRequest replyMessageRequest)
        {
            if (replyMessageRequest == null)
            {
                throw new ArgumentNullException(nameof(ReplyMessageRequest));
            }

            var request = new LinePostRequest<ResponseItem>(this, "bot/message/reply");

            return await request.Execute(replyMessageRequest);
        }

        /// <summary>
        /// Send message to multiple 
        /// </summary>
        /// <param name="multiCastMessageRequest"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> MulticastMessage(MultiCastMessageRequest multiCastMessageRequest)
        {
            if (multiCastMessageRequest == null)
            {
                throw new ArgumentNullException(nameof(MultiCastMessageRequest));
            }

            var request = new LinePostRequest<ResponseItem>(this, "bot/message/multicast");

            return await request.Execute(multiCastMessageRequest);
        }

        /// <summary>
        /// Get message content
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<Stream>> GetMessageContent(string messageId)
        {
            if (!string.IsNullOrWhiteSpace(messageId))
            {
                throw new ArgumentNullException("The property message id should not be null or empty");
            }

            var request = new LineGetStreamRequest<Stream>(this, $"bot/message/{messageId}/content");

            return await request.ExecuteStreamServiceCall<Stream>(null);
        }
    }
}
