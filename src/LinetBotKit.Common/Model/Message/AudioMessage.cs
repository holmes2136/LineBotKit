using LinetBotKit.Common.Model.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model.Message
{
    public class AudioMessage : Message
    {
        public override MessageType type => MessageType.Audio;
        private Uri _originalContentUrl;
        private int _duration;

        public AudioMessage(Uri originalContentUrl, int duration)
        {
            this.OriginalContentUrl = originalContentUrl;
            this.Duration = duration;
        }

        /// <summary>
        /// originalContentUrl
        /// </summary>
        [JsonProperty("originalContentUrl")]
        public Uri OriginalContentUrl
        {
            get
            {
                return _originalContentUrl;
            }

            set
            {
                _originalContentUrl = value.ValidateUrl();
            }
        }

        /// <summary>
        /// duration
        /// </summary>
        [JsonProperty("duration")]
        public int Duration
        {
            get
            {
                return _duration;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("The duration property must be at least 1 millisecond");
                }
                else if (value >= 60000)
                {
                    throw new ArgumentException("The duration property can't be bigger than 1 minute");
                }
                _duration = value;
            }
        }
    }
}
