using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LineBotKit.Common.Model.Actions;

namespace LineBotKit.Common.Model.RichMenu
{
    public class Area
    {
       public Bounds bounds { get; set; }
       public Actions.Action action { get; set; }
    }
}
