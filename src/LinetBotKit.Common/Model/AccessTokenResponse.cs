﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model
{
    public class AccessTokenResponse
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
    }
}
