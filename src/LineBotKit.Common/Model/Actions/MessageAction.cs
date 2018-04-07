using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Actions
{
    public class MessageAction:Action
    {
        public string text { get; set; }

        public MessageAction() {
            this.type = ActionType.Message;
        }
    }
}
