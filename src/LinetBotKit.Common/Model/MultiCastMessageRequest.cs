using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model
{
    public class MultiCastMessageRequest
    {
        public IList<string> to { get; set; }
        public IList<Message.Message> messages { get; set; }
    }
}
