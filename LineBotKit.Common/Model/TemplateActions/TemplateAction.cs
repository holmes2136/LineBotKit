﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.TemplateActions
{
    public class TemplateAction
    {
        public string label { get; set; }

        public TemplateActionType type
        {
            get;
            set;
        }
    }
}
