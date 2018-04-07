using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Actions
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
