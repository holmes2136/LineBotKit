using System;
using System.Collections.Generic;
using System.Text;

namespace LineBotKit.Client.Response
{
    public class LineClientResult<T> : LineClientResultBase
    {
        public T Response { get; set; }
    }
}
