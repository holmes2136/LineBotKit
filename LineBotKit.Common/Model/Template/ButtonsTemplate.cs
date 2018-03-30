using LineBotKit.Common.Model.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Template
{
    public class ButtonsTemplate:Template
    {
        public string thumbnailImageUrl { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public Actions.Action defaultAction { get; set; }
        public List<Actions.Action> actions { get; set; }

        public ButtonsTemplate(string thumbnailImageUrl = null, string title = null, string text = null, List<Actions.Action> actions = null) {
            this.type = TemplateType.Buttons;
            this.actions = (actions ?? new List<Actions.Action>());
        }
    }
}
