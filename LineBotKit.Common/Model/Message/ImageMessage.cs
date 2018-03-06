using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Message
{
    public class ImageMessage:Message
    {
        public string originalContentUrl { get; set; }
        public string previewImageUrl { get; set; }

        public ImageMessage(string originalContentUrl,string previewImageUrl) {
            this.type = MessageType.Image;
            this.originalContentUrl = originalContentUrl;
            this.previewImageUrl = previewImageUrl;
        }
    }
}
