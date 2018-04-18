using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model
{
    public class PushMessageRequest
    {
        public PushMessageRequest()
        {
            messages = new List<Message.Message>();
        }

        public string to { get; set; }

        public IList<Message.Message> messages { get; set; }
    }
}
