using LineBotKit.Common.Model;
using LineBotKit.Common.Model.Message;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public interface IMessageClient
    {

        Task<ResponseItem> PushMessage(PushMessageRequest message);

        Task<ResponseItem> MulticastAsync(MultiCastMessageRequest messages);

        Task<ResponseItem> ReplyMessage(ReplyMessageRequest message);

        Stream GetMessageContent(string messageId);
    }


}
