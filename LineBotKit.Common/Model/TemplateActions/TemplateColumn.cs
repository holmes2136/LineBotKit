using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.TemplateActions
{
    public class TemplateColumn
    {
        public string title { get; set; }

        public string text { get; set; }

        public string ThumbnailImageUrl { get; set; }

        public List<TemplateAction> actions { get; set; }

        public TemplateColumn() {
            this.actions = new List<TemplateAction>();
        }
    }
}
