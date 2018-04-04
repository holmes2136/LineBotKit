using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Template
{
    public class ImageCarouselTemplateColumn
    {
        public string imageUrl { get; set; }
        public Actions.Action action { get; set; }

        public ImageCarouselTemplateColumn() {
        }
    }
}
