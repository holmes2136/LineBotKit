﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LineBotKit.Common.Model.Actions;

namespace LineBotKit.Common.Model.Template
{
    public class ConfirmTemplate:Template
    {
        public new string type = "confirm";
        public string text { get; set; }
        public List<Actions.Action> actions { get; set; }

        public ConfirmTemplate(string text = null, List<Actions.Action> actions = null)
        {
            this.actions = (actions ?? new List<Actions.Action>());
        }
    }
}
