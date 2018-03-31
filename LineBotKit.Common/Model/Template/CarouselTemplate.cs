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
        public List<TemplateColumn> columns { get; set; }

        /// <summary>
        /// Aspect ratio of the image
        /// </summary>
        public ImageAspectRatioType imageAspectRatio { get; set; }

        /// <summary>
        /// Size of the image
        /// </summary>
        public ImageSizeType imageSize { get; set; }
        public CarouselTemplate() {
            this.type = TemplateType.Carousel;
        }
               
    }
}
