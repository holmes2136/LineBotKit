using System;
using System.Collections.Generic;

namespace LinetBotKit.Common.Model
{
    public class ResponseItem
    {
        public string message { get; set; }

        public IList<ResponseItemDetail> details { get; set; }
    }
}
