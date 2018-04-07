using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Template
{
    public abstract class Template
    {
        public  virtual TemplateType type { get; internal set; }

        public Template() {

        }
    }
}
