using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model.Actions
{
    public class MessageAction : Action
    {
        public string text { get; set; }

        public MessageAction()
        {
            this.type = ActionType.Message;
        }
    }
}
