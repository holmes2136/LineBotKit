using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model
{
    public class ReplyMessageRequest
    {
        public ReplyMessageRequest() {

        }
        public string replyToken { get; set; }

        public List<Message.Message> messages { get; set; }
    }
}
