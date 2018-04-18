using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model.Message
{
    public class TextMessage : Message
    {
        public override MessageType type => MessageType.Text;
        private string _text;

        public TextMessage(string text)
        {
            this.Text = text;
        }

        /// <summary>
        /// text
        /// </summary>
        [JsonProperty("text")]
        public string Text
        {
            get
            {
                return _text;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException("The text property can't be null or whitespace");
                }
                else if (value.Length > 2000)
                {
                    throw new ArgumentException("The text property can't be bigger than 2000 characters");
                }
                _text = value;
            }
        }
    }
}
