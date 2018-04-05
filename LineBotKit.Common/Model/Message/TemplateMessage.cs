using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using LineBotKit.Common.Model.Template;

namespace LineBotKit.Common.Model.Message
{
    public class TemplateMessage:Message
    {
        public override MessageType type => MessageType.Template;
        private string _altText;
        private Template.Template _template;


        public TemplateMessage(string altText , Template.Template template) {
            this.AltText = altText;
            this.Template = template;
        }

        /// <summary>
        /// altText
        /// </summary>
        [JsonProperty("altText")]
        public string AltText
        {
            get
            {
                return _altText;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The altText property can't be null or whitespace");
                }
                else if (value.Length > 400) {
                    throw new ArgumentException("The altText property can't be bigger than 400 characters");
                }
                _altText = value;
            }
        }

        /// <summary>
        /// template
        /// </summary>
        [JsonProperty("template")]
        public Template.Template Template
        {
            get
            {
                return _template;
            }

            set
            {
                var instance = value.GetType().GetTypeInfo();

                if (value == null) {
                    throw new InvalidOperationException("The template cannot be null.");
                }
                else if (!instance.Equals(typeof(ButtonsTemplate)) &&
                    !instance.Equals(typeof(ConfirmTemplate)) &&
                    !instance.Equals(typeof(CarouselTemplate)) &&
                    !instance.Equals(typeof(ImageCarouselTemplate))) {
                    throw new ArgumentException("The template type is not valid");
                }
                _template = value;
            }
        }
    }
}
