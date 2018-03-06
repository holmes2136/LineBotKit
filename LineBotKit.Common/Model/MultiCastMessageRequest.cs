using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model
{
    public class MultiCastMessageRequest
    {
        public List<string> to { get; set; }
        public List<Message.Message> messages { get; set; }
    }
}
