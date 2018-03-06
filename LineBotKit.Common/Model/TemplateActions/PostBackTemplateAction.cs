using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.TemplateActions
{
    public class PostBackTemplateAction:TemplateAction
    {
        public string data { get; set; }

        public string text { get; set; }

        public PostBackTemplateAction() {
            this.type = TemplateActionType.Postback;
        }

    }
}
