using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model.Actions
{
    public class PostBackAction : Action
    {
        public string data { get; set; }

        [Obsolete("Text property will deprecated, please use displayText property.")]
        public string text { get; set; }

        public string displayText { get; set; }

        public PostBackAction()
        {
            this.type = ActionType.Postback;
        }

    }
}
