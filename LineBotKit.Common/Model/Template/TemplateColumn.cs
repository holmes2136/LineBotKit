using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Actions
{
    public class TemplateColumn
    {
        public string title { get; set; }

        public string text { get; set; }

        public string ThumbnailImageUrl { get; set; }

        public Action defaultAction { get; set; }

        public List<Action> actions { get; set; }

        public TemplateColumn() {
            this.actions = new List<Action>();
        }
    }
}
