using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model
{
    public class MemberIdensResponse
    {
        public IList<string> memberIds { get; set; }
        public string next { get; set; }
    }
}
