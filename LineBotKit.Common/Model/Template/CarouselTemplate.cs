using LineBotKit.Common.Model.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Template
{
    public class CarouselTemplate : Template
    {
        public IList<CarouselTemplateColumn> columns { get; set; }
        public override TemplateType type => TemplateType.Carousel;

        /// <summary>
        /// Aspect ratio of the image
        /// </summary>
        public ImageAspectRatioType imageAspectRatio { get; set; }

        /// <summary>
        /// Size of the image
        /// </summary>
        public ImageSizeType imageSize { get; set; }
        public CarouselTemplate() {
        }
               
    }
}
