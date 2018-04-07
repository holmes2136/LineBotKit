using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Actions
{
    public class ImageMapUriAction:ImageMapAction
    {
        public string linkUri { get; set; }

        public ImageMapUriAction(string linkUri, string label , Area area) {
            this.linkUri = linkUri;
            base.label = label;
            base.area = area;
            this.type = ActionType.Uri;
        }
    }
}
