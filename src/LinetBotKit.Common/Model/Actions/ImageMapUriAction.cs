using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model.Actions
{
    public class ImageMapUriAction : ImageMapAction
    {
        public string linkUri { get; set; }

        public ImageMapUriAction(string linkUri, string label, Area area)
        {
            this.linkUri = linkUri;
            base.label = label;
            base.area = area;
            this.type = ActionType.Uri;
        }
    }
}
