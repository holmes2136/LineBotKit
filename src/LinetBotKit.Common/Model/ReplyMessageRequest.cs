using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model
{
    public class ReplyMessageRequest
    {
        public ReplyMessageRequest() {}

        public IList<string> replyTokens { get; set; }

        public IList<Message.Message> messages { get; set; }
    }
}
