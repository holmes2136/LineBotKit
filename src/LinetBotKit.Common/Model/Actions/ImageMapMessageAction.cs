using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model.Actions
{
    public class ImageMapMessageAction : ImageMapAction
    {
        public string text { get; set; }

        public ImageMapMessageAction(string text, string label, Area area)
        {
            this.text = text;
            base.label = label;
            base.area = area;
            this.type = ActionType.Message;
        }
    }
}
