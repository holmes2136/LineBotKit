using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.WebHook
{
    public class Event
    {
        public string type { get; set; }

        public string replyToken { get; set; }

        public Source source { get; set; }

        public long timestamp { get; set; }

        public Message message { get; set; }

        public PostBack postback { get; set; }

    }
}
