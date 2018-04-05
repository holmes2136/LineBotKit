using LineBotKit.Common.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Message
{
    public class ImageMessage:Message
    {
        public override MessageType type => MessageType.Image;
        private Uri _originalContentUrl;
        private Uri _previewImageUrl;

        public ImageMessage(Uri originalContentUrl, Uri previewImageUrl) {
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
