using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model.RichMenu
{
    public class RichMenu
    {
        public string richMenuId { get; set; }
        public Size size { get; set; }
        public bool selected { get; set; }
        public string name { get; set; }
        public string chatBarText { get; set; }
        public IList<Area> areas { get; set; }
    }
}
