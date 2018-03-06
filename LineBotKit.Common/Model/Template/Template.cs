using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Template
{
    public abstract class Template
    {
        public  string type { get;  set; }
        public Template() {
            this.type = "template";
        }
    }
}
