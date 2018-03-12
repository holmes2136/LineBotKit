using LineBotKit.Common.Model;
using LineBotKit.Common.Model.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public class LineClientManager : ILineClientManager
    {

        public string _ChannelAccessToken { get; set; }
        public MessageClient messageClient { get; set; }
        public RoomClient roomClient { get; set; }
        public UserClient userClient { get; set; }
        public GroupClient groupClient { get; set; }

        public LineClientManager(string ChannelAccessToken)
        {
            this._ChannelAccessToken = ChannelAccessToken;
            this.messageClient = new MessageClient(ChannelAccessToken);
            this.userClient = new UserClient(ChannelAccessToken);
            this.groupClient = new GroupClient(ChannelAccessToken);
            this.roomClient = new RoomClient(ChannelAccessToken);
        }

        public MessageClient GetMessageClient()
        {
            return this.messageClient;
        }

        public async Task<ResponseItem> PushTextMessage(string to, string message)
        {
            var pushMessageRequest = new PushMessageRequest()
            {
                to = to,
                messages = new List<Message>() {
                     new TextMessage(message)
                }
            };
            return await messageClient.PushMessage(pushMessageRequest);
        }

        public async Task<ResponseItem> PushImageMessage(string to, string imageContentUrl, string imagePreviewUrl)
        {
            Uri imgContentUrl = new Uri(imageContentUrl);
            Uri imgePreviewUrl = new Uri(imagePreviewUrl);

            var pushMessageRequest = new PushMessageRequest()
            {
                to = to,
                messages = new List<Message>() {
                    new ImageMessage(imgContentUrl.AbsoluteUri,imgePreviewUrl.AbsoluteUri)
                }
            };

            return await messageClient.PushMessage(pushMessageRequest);
        }

        public async Task<ResponseItem> PushStickerMessage(string to, int packageId, int stickerId)
        {
            var pushMessageRequest = new PushMessageRequest()
            {
                to = to,
                messages = new List<Message>() {
                      new StickerMessage(packageId,stickerId)
                }
            };

            return await messageClient.PushMessage(pushMessageRequest);
        }

        /// <summary>
        /// Send audio message
        /// </summary>
        /// <param name="to"></param>
        /// <param name="originalContentUrl">URL of audio file (Max: 1000 characters),HTTPS,m4a,Max: 1 minute,Max: 10 MB</param>
        /// <param name="duration">Length of audio file (milliseconds)</param>
        /// <returns></returns>
        public async Task<ResponseItem> PushAudioMessage(string to, string originalContentUrl, int duration)
        {
            var pushMessageRequest = new PushMessageRequest()
            {
                to = to,
                messages = new List<Message>() {
                      new AudioMessage(originalContentUrl,duration)
                }
            };

            return await messageClient.PushMessage(pushMessageRequest);
        }

        public async Task<ResponseItem> PushMessage(PushMessageRequest pushMessageRequest)
        {
            if (pushMessageRequest.messages.Count > 5)
            {
                throw new ArgumentException("Only allow maximun 5 messages");
            }

            return await messageClient.PushMessage(pushMessageRequest);
        }

        public async Task<ResponseItem> ReplyTextMessage(string replyToken,string message)
        {
            var replyMessageRequest = new ReplyMessageRequest()
            {
                replyToken = replyToken,
                messages = new List<Message>()
                {
                   new TextMessage(message)
                }
            };
          
            return await messageClient.ReplyMessage(replyMessageRequest);
        }

        public async Task<ResponseItem> ReplyImageMessage(string replyToken, string imageContentUrl, string imagePreviewUr)
        {
            Uri imgContentUrl = new Uri(imageContentUrl);
            Uri imgePreviewUrl = new Uri(imagePreviewUr);

            var replyMessageRequest = new ReplyMessageRequest()
            {
                replyToken = replyToken,
                messages = new List<Message>()
                {
                   new ImageMessage(imgContentUrl.AbsoluteUri,imgePreviewUrl.AbsoluteUri)
                }
            };

            return await messageClient.ReplyMessage(replyMessageRequest);
        }

        public async Task<ResponseItem> ReplyStickerMessage(string replyToken, int packageId, int stickerId)
        {

            var replyMessageRequest = new ReplyMessageRequest()
            {
                replyToken = replyToken,
                messages = new List<Message>()
                {
                   new StickerMessage(packageId,stickerId)
                }
            };

            return await messageClient.ReplyMessage(replyMessageRequest);
        }

        public async Task<ResponseItem> ReplyMessage(ReplyMessageRequest reply)
        {

            return await messageClient.ReplyMessage(reply);
        }

        public async Task<ResponseItem> MulticastAsync(List<string> to, List<Message> messages)
        {

            if (to.Count > 150)
            {
                throw new ArgumentException("Maximum to are 150 users");
            }

            if (messages.Count > 5)
            {
                throw new ArgumentException("Maximum 5 messages");
            }

            MultiCastMessageRequest multicastMessage = new MultiCastMessageRequest()
            {
                to = to,
                messages = messages
            };
            return await messageClient.MulticastAsync(multicastMessage);

        }

        public async Task<Profile> GetProfile(string userId)
        {
            return await userClient.GetProfile(userId);
        }

        public async Task<ResponseItem> LeaveGroup(string groupId)
        {
            return await groupClient.Leave(groupId);
        }

        public async Task<Profile> GetGroupMemberProfile(string userId, string groupId)
        {
            return await groupClient.GetMemberProfile(userId, groupId);

        }

        public async Task<Profile> GetRoomMemberProfile(string userId, string roomId)
        {
            return await roomClient.GetMemberProfile(userId, roomId);
        }

        public async Task<ResponseItem> GetGroupMemberIds(string groupId)
        {
            return await groupClient.GetMemberIds(groupId);
        }

        public async Task<ResponseItem> GetRoomMemberIds(string roomId)
        {
            return await roomClient.GetMemberIds(roomId);
        }
    }
}
