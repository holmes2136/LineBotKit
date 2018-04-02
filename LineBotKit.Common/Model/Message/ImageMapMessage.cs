using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LineBotKit.Common.Model.Actions;

namespace LineBotKit.Common.Model.Message
{
    public class ImageMapMessage : Message
    {
        public string baseUrl { get; set; }
        public string altText { get; set; }
        public BaseSize baseSize { get; set; }
        public IList<ImageMapAction> actions { get; set; }

        public ImageMapMessage(string baseUrl , string altText , BaseSize baseSize)
        {
            this.type = MessageType.Imagemap;
            this.baseUrl = baseUrl;
            this.altText = altText;
            this.baseSize = baseSize;
            this.actions = new List<ImageMapAction>();
        }

        public void Add(IList<ImageMapAction> actions) {
            this.actions = actions;
        }
    }
}
