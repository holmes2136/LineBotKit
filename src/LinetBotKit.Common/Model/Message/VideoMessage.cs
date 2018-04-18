using LinetBotKit.Common.Model.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model.Message
{
    public class VideoMessage : Message
    {
        public override MessageType type => MessageType.Video;
        private Uri _originalContentUrl;
        private Uri _previewImageUrl;

        public VideoMessage(Uri originalContentUrl, Uri previewImageUrl)
        {
            this.OriginalContentUrl = originalContentUrl;
            this.PreviewImageUrl = previewImageUrl;
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
        /// previewImageUrl
        /// </summary>
        [JsonProperty("previewImageUrl")]
        public Uri PreviewImageUrl
        {
            get
            {
                return _previewImageUrl;
            }

            set
            {
                _previewImageUrl = value.ValidateUrl();
            }
        }
    }
}
