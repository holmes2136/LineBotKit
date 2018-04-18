using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model.RichMenu
{
    public class Bounds
    {
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public Bounds(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
    }
}
