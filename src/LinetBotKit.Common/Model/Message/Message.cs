using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model.Message
{
    public abstract class Message
    {
        public Message(){}

        public virtual MessageType type { get; internal set; }
    }
}
