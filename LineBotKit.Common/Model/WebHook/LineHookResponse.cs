using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.WebHook
{
    public class LineHookResponse
    {
        public List<Event> events { get; set; }
    }
}
