using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Message
{
    public class StickerMessage:Message
    {
        public override MessageType type => MessageType.Sticker;
        private int _packageId;
        private int _stickerId;

        public StickerMessage(int packageId, int stickerId)
        {
            this.PackageId = packageId;
            this.StickerId = stickerId;
        }

        /// <summary>
        /// packageId
        /// </summary>
        [JsonProperty("packageId")]
        public int PackageId
        {
            get
            {
                return _packageId;
            }

            set
            {
                if (value <= 0)
                    throw new ArgumentException("The package id property can't be zero");

                _packageId = value;
            }
        }

        /// <summary>
        /// stickerId
        /// </summary>
        [JsonProperty("stickerId")]
        public int StickerId
        {
            get
            {
                return _stickerId;
            }

            set
            {
                if (value <= 0)
                    throw new ArgumentException("The sticker id property can't be zero");

                _stickerId = value;
            }
        }
    }
}
