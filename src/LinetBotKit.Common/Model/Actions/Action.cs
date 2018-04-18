using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model.Actions
{
    public class Action
    {
        public string label { get; set; }

        public ActionType type
        {
            get;
            internal set;
        }
    }
}
