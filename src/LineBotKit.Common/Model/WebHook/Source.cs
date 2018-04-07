using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.WebHook
{
    public class Source
    {
        public string groupId { get; set; }

        public string userId { get; set; }

        public string type { get; set; }

        public string roomId { get; set; }
    }
}
