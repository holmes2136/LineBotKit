using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.WebHook
{
    public class PostBack
    {
        public string data { get; set; }

        public Params Params { get; set; }
    }
}
