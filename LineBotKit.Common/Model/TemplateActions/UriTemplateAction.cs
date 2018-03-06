using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.TemplateActions
{
    public class UriTemplateAction:TemplateAction
    {
        public string uri { get; set; }

        public UriTemplateAction() {
            this.type = TemplateActionType.Uri;
        }
    }
}
