using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.TemplateActions
{
    public class MessageTemplateAction:TemplateAction
    {
        public string text { get; set; }

        public MessageTemplateAction() {
            this.type = TemplateActionType.Message;
        }
    }
}
