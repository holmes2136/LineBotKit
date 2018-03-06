using LineBotKit.Common.Model.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model
{
    public class ImageMapChild
    {
        public string type = MessageType.ImageMap.ToString();

        public string baseUrl { get; set; }

        public string altText { get; set; }

        public BaseSize baseSize { get; set; }
        public string actions {get;set;}
    }
}
