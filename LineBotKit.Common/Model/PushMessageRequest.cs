using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LineBotKit.Common.Model.Message;

namespace LineBotKit.Common.Model
{
    public class PushMessageRequest
    {

        public PushMessageRequest() {
            messages = new List<Message.Message>();
        }

        public string to { get; set; }

        public List<Message.Message> messages { get; set; }
    }
}
