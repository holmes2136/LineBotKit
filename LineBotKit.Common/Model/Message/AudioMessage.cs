using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Message
{
    public class AudioMessage:Message
    {
        public string originalContentUrl { get; set; }
        public int duration { get; set; }

        public AudioMessage(string originalContentUrl, int duration)
        {
            this.type = MessageType.Audio;
            this.originalContentUrl = originalContentUrl;
            this.duration = duration;
        }
    }
}
