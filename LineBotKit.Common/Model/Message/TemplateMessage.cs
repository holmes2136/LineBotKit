using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Message
{
    public class TemplateMessage:Message
    {
        public string altText { get; set; }

        public Template.Template template { get; set; }

        public TemplateMessage() {
            this.type = MessageType.Template;
        }
    }
}
