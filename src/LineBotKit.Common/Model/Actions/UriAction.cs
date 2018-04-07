using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Actions
{
    public class UriAction:Action
    {
        public string uri { get; set; }

        public UriAction() {
            this.type = ActionType.Uri;
        }
    }
}
