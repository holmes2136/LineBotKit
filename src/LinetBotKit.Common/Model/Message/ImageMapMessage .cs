using LinetBotKit.Common.Model.Actions;
using LinetBotKit.Common.Model.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model.Message
{
    public class ImageMapMessage : Message
    {
        public override MessageType type => MessageType.Imagemap;
        private Uri _baseUrl;
        private string _altText;
        private BaseSize _baseSize;
        private IList<ImageMapAction> _actions;

        public ImageMapMessage(Uri baseUrl, string altText, BaseSize baseSize)
        {
            this.BaseUrl = baseUrl;
            this.AltText = altText;
            this.BaseSize = baseSize;
            this._actions = new List<ImageMapAction>();
        }

        /// <summary>
        /// baseUrl
        /// </summary>
        [JsonProperty("baseUrl")]
        public Uri BaseUrl
        {
            get
            {
                return _baseUrl;
            }

            set
            {
                _baseUrl = value.ValidateUrl();
            }
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
                    throw new ArgumentException("The alt text property can't be null or whitespace");
                }
                else if (value.Length > 400)
                {
                    throw new ArgumentException("The alt text property can't be bigger than 400 characters");
                }

                _altText = value;
            }
        }

        /// <summary>
        /// baseSize
        /// </summary>
        [JsonProperty("baseSize")]
        public BaseSize BaseSize
        {
            get
            {
                return _baseSize;
            }

            set
            {
                _baseSize = value ?? throw new ArgumentException("The base size porperty can't be null");
            }
        }

        /// <summary>
        /// actions
        /// </summary>
        [JsonProperty("actions")]
        public IList<ImageMapAction> Actions
        {
            get
            {
                return _actions;
            }

            set
            {
                _actions = value ?? throw new ArgumentException("The actions property can't be null");
            }
        }

        public void Add(ImageMapAction actions)
        {
            this._actions.Add(actions);
        }
    }
}
