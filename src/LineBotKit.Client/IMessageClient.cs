using LineBotKit.Client.Response;
using LinetBotKit.Common.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public interface IMessageClient
    {
        Task<LineClientResult<ResponseItem>> PushMessage(PushMessageRequest message);
        Task<LineClientResult<ResponseItem>> MulticastMessage(MultiCastMessageRequest messages);
        Task<LineClientResult<ResponseItem>> ReplyMessage(ReplyMessageRequest message);
        Task<LineClientResult<Stream>> GetMessageContent(string messageId);
    }
}
