using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model
{
    public class MemberIdensResponse
    {
        public IList<string> memberIds { get; set; }
        public string next { get; set; }
    }
}
