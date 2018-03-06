using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Message
{
    public class StickerMessage:Message
    {
        public int packageId { get; set; }
        public int stickerId { get; set; }

        public StickerMessage(int packageId, int stickerId) {
            this.type = MessageType.Sticker;
            this.packageId = packageId;
            this.stickerId = stickerId;
        }


    }
}
