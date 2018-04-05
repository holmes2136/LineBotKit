using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Message
{
    public abstract class Message
    {
        public Message() {

        }

        public virtual MessageType type { get; internal set; }


    }
}
