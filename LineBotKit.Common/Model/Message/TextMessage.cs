using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace LineBotKit.Common.Model.Message
{
    public class TextMessage:Message
    {
        public string text { get; set; }

        public TextMessage(string text) {
            this.type = MessageType.Text;
            this.text = text;
        }
    }
}
