using LineBotKit.Common.Model.TemplateActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Template
{
    public class ConfirmTemplate:Template
    {
        public new string type = "confirm";
        public string text { get; set; }
        public List<TemplateAction> actions { get; set; }

        public ConfirmTemplate(string text = null, List<TemplateAction> actions = null)
        {
            this.actions = (actions ?? new List<TemplateAction>());
        }
    }
}
