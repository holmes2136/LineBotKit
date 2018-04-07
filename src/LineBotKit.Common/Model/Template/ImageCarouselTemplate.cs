using LineBotKit.Common.Model.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Template
{
    public class ImageCarouselTemplate: Template
    {
        public override TemplateType type => TemplateType.Image_carousel;

        public IList<ImageCarouselTemplateColumn> columns { get; set; }

        public ImageCarouselTemplate() {

        }
    }
}
