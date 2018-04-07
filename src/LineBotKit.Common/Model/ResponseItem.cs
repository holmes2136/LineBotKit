using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model
{
    public class ResponseItem
    {
        public string message { get; set; }

        public List<ResponseItemDetail> details { get; set; }
    }
}
