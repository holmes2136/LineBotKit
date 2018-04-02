﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model
{
    public class BaseSize
    {
        public int height { get; set; }

        public int width { get; set; }

        public BaseSize(int height , int width) {
            this.height = height;
            this.width = width;
        }
    }
}
