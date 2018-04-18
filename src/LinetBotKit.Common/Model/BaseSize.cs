using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model
{
    public class BaseSize
    {
        public int height { get; set; }

        public int width { get; set; }

        public BaseSize(int height, int width)
        {
            this.height = height;
            this.width = width;
        }
    }
}
