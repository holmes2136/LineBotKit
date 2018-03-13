using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Message
{
    public class VideoMessage:Message
    {
        public string originalContentUrl { get; set; }
        public string previewImageUrl { get; set; }

        public VideoMessage(string originalContentUrl, string previewImageUrl)
        {
            this.type = MessageType.Video;
            this.originalContentUrl = originalContentUrl;
            this.previewImageUrl = previewImageUrl;
        }
    }
}
