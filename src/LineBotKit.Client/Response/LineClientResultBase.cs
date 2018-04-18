using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LineBotKit.Client.Response
{
    public class LineClientResultBase
    {
        public HttpStatusCode StatusCode { get; set; }

        public bool IsSuccessStatusCode { get; set; }
    }
}
