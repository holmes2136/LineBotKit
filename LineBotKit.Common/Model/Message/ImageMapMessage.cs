using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Message
{
    public class ImageMapMessage:Message
    {
        public List<ImageMapChild> messages { get; set; }

        public ImageMapMessage() {
            this.type = MessageType.ImageMap;
        }
    }
}
