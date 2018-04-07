using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Actions
{
    public class PostBackAction:Action
    {
        public string data { get; set; }

        [Obsolete("Text property will deprecated, please use displayText property.")]
        public string text { get; set; }

        public string displayText { get; set; }

        public PostBackAction() {
            this.type = ActionType.Postback;
        }

    }
}
