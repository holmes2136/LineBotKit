using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model.Actions
{
    public class UriAction : Action
    {
        public string uri { get; set; }

        public UriAction(string uri)
        {
            this.type = ActionType.Uri;
            this.uri = uri;
        }
    }
}
