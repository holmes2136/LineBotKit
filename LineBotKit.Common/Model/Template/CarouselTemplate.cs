using LineBotKit.Common.Model.TemplateActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Template
{
    public class CarouselTemplate:Template
    {
        public new string type = "carousel";
        public List<TemplateColumn> columns { get; set; }
    }
}
