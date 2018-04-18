using LineBotKit.Client.Request;
using LineBotKit.Client.Response;
using LinetBotKit.Common.Model;
using LinetBotKit.Common.Model.Message;
using LinetBotKit.Common.Model.RichMenu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public class LineClientManager:ILineClientManager
    {
        private MessageClient messageClient { get; set; }
        private UserClient userClient { get; set; }
        private GroupClient groupClient { get; set; }
        private RoomClient roomClient { get; set; }
        private AuthenticateClient authenticateClient { get; set; }
        private RichMenuClient richMenuClient { get; set; }

        public LineClientManager(string channelAccessToken)
        {
            this.messageClient = new MessageClient(channelAccessToken);
            this.userClient = new UserClient(channelAccessToken);
            this.groupClient = new GroupClient(channelAccessToken);
            this.roomClient = new RoomClient(channelAccessToken);
            this.authenticateClient = new AuthenticateClient(channelAccessToken);
            this.richMenuClient = new RichMenuClient(channelAccessToken);
        }

        #region Send message related

        /// <summary>
        /// Send text message
        /// </summary>
        /// <param name="to"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> PushTextMessage(string to, string message)
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

        /// <summary>
        /// Send image message
        /// </summary>
        /// <param name="to"></param>
        /// <param name="imageContentUrl"></param>
        /// <param name="imagePreviewUrl"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> PushImageMessage(string to, string imageContentUrl, string imagePreviewUrl)
        {
            Uri imgContentUrl = new Uri(imageContentUrl);
            Uri imgePreviewUrl = new Uri(imagePreviewUrl);

            var pushMessageRequest = new PushMessageRequest()
            {
                to = to,
                messages = new List<Message>() {
                    new ImageMessage(imgContentUrl,imgePreviewUrl)
                }
            };

            return await messageClient.PushMessage(pushMessageRequest);
        }

        /// <summary>
        /// Send sticker message
        /// </summary>
        /// <param name="to"></param>
        /// <param name="packageId"></param>
        /// <param name="stickerId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> PushStickerMessage(string to, int packageId, int stickerId)
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
        public async Task<LineClientResult<ResponseItem>> PushAudioMessage(string to, string originalContentUrl, int duration)
        {
            Uri _originalContentUrl = new Uri(originalContentUrl);

            var pushMessageRequest = new PushMessageRequest()
            {
                to = to,
                messages = new List<Message>() {
                      new AudioMessage(_originalContentUrl,duration)
                }
            };

            return await messageClient.PushMessage(pushMessageRequest);
        }

        /// <summary>
        /// Send video message
        /// </summary>
        /// <param name="to"></param>
        /// <param name="originalContentUrl">URL of video file (Max: 1000 characters) ,HTTPS,mp4,Max: 1 minute,Max: 10 MB</param>
        /// <param name="previewImageUrl">URL of preview image (Max: 1000 characters),HTTPS,JPEG,Max: 240 x 240,Max: 1 MB</param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> PushVideoMessage(string to, string originalContentUrl, string previewImageUrl)
        {
            Uri _originalContentUrl = new Uri(originalContentUrl);
            Uri _previewImageUrl = new Uri(previewImageUrl);

            var pushMessageRequest = new PushMessageRequest()
            {
                to = to,
                messages = new List<Message>() {
                      new VideoMessage(_originalContentUrl,_previewImageUrl)
                }
            };

            return await messageClient.PushMessage(pushMessageRequest);
        }

        /// <summary>
        /// Send location message
        /// </summary>
        /// <param name="to"></param>
        /// <param name="title"></param>
        /// <param name="address"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> PushLocationMessage(string to, string title, string address, decimal latitude, decimal longitude)
        {
            var pushMessageRequest = new PushMessageRequest()
            {
                to = to,
                messages = new List<Message>() {
                      new LocationMessage(title,address,latitude,longitude)
                }
            };

            return await messageClient.PushMessage(pushMessageRequest);
        }

        /// <summary>
        /// Send image map messages
        /// </summary>
        /// <param name="to"></param>
        /// <param name="imageMapMessages"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> PushImageMapMessage(string to, ImageMapMessage imageMapMessages)
        {
            var pushMessageRequest = new PushMessageRequest()
            {
                to = to,
                messages = new List<Message>() { imageMapMessages }
            };

            return await messageClient.PushMessage(pushMessageRequest);
        }

        /// <summary>
        /// Send message
        /// </summary>
        /// <param name="pushMessageRequest"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> PushMessage(PushMessageRequest pushMessageRequest)
        {
            if (pushMessageRequest.messages.Count > 5)
            {
                throw new ArgumentException("Only allow maximun 5 messages");
            }

            return await messageClient.PushMessage(pushMessageRequest);
        }

        /// <summary>
        /// Gets image, video, and audio data sent by users.
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public  async Task<LineClientResult<Stream>> GetMessageContent(string messageId)
        {
            return await messageClient.GetMessageContent(messageId);
        }

        /// <summary>
        /// Send message to multiple user
        /// </summary>
        /// <param name="to"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> MulticastMessage(List<string> to, List<Message> messages)
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
            return await messageClient.MulticastMessage(multicastMessage);
        }

        #endregion

        #region reply message related

        /// <summary>
        /// Reply text message
        /// </summary>
        /// <param name="replyToken"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> ReplyTextMessage(string replyToken, string message)
        {
            var replyMessageRequest = new ReplyMessageRequest()
            {
                replyTokens = new List<String>() {
                    replyToken
                }
                ,
                messages = new List<Message>()
                {
                   new TextMessage(message)
                }
            };

            return await messageClient.ReplyMessage(replyMessageRequest);
        }

        /// <summary>
        /// Reply image message
        /// </summary>
        /// <param name="replyToken"></param>
        /// <param name="imageContentUrl"></param>
        /// <param name="imagePreviewUr"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> ReplyImageMessage(string replyToken, string imageContentUrl, string imagePreviewUr)
        {
            Uri imgContentUrl = new Uri(imageContentUrl);
            Uri imgePreviewUrl = new Uri(imagePreviewUr);

            var replyMessageRequest = new ReplyMessageRequest()
            {
                replyTokens = new List<string>() {
                    replyToken
                }
                ,
                messages = new List<Message>()
                {
                   new ImageMessage(imgContentUrl,imgePreviewUrl)
                }
            };

            return await messageClient.ReplyMessage(replyMessageRequest);
        }

        /// <summary>
        /// Reply sticker message
        /// </summary>
        /// <param name="replyToken"></param>
        /// <param name="packageId"></param>
        /// <param name="stickerId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> ReplyStickerMessage(string replyToken, int packageId, int stickerId)
        {

            var replyMessageRequest = new ReplyMessageRequest()
            {
                replyTokens = new List<string>() {
                    replyToken
                }
                ,
                messages = new List<Message>()
                {
                   new StickerMessage(packageId,stickerId)
                }
            };

            return await messageClient.ReplyMessage(replyMessageRequest);
        }

        /// <summary>
        /// Reply audio message
        /// </summary>
        /// <param name="replyToken"></param>
        /// <param name="to"></param>
        /// <param name="originalContentUrl"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> ReplyAudioMessage(string replyToken, string to, string originalContentUrl, int duration)
        {
            Uri _originalContentUrl = new Uri(originalContentUrl);

            var replyMessageRequest = new ReplyMessageRequest()
            {
                replyTokens = new List<string>() {
                    replyToken
                }
                ,
                messages = new List<Message>() {
                      new AudioMessage(_originalContentUrl,duration)
                }
            };

            return await messageClient.ReplyMessage(replyMessageRequest);
        }

        /// <summary>
        /// Reply video message
        /// </summary>
        /// <param name="replyToken"></param>
        /// <param name="to"></param>
        /// <param name="originalContentUrl"></param>
        /// <param name="previewImageUrl"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> ReplyVideoMessage(string replyToken, string to, string originalContentUrl, string previewImageUrl)
        {
            Uri _originalContentUrl = new Uri(originalContentUrl);
            Uri _previewImageUrl = new Uri(previewImageUrl);

            var replyMessageRequest = new ReplyMessageRequest()
            {
                replyTokens = new List<string>() {
                    replyToken
                }
                ,
                messages = new List<Message>() {
                      new VideoMessage(_originalContentUrl,_previewImageUrl)
                }
            };

            return await messageClient.ReplyMessage(replyMessageRequest);
        }

        /// <summary>
        /// Reply location message
        /// </summary>
        /// <param name="replyToken"></param>
        /// <param name="to"></param>
        /// <param name="title"></param>
        /// <param name="address"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> ReplyLocationMessage(string replyToken, string to, string title, string address, decimal latitude, decimal longitude)
        {
            var replyMessageRequest = new ReplyMessageRequest()
            {
                replyTokens = new List<string>() {
                    replyToken
                }
                ,
                messages = new List<Message>() {
                      new LocationMessage(title,address,latitude,longitude)
                }
            };

            return await messageClient.ReplyMessage(replyMessageRequest);
        }

        /// <summary>
        /// Reply image message
        /// </summary>
        /// <param name="replyToken"></param>
        /// <param name="to"></param>
        /// <param name="imageMapMessages"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> ReplyImageMapMessage(string replyToken, string to, ImageMapMessage imageMapMessages)
        {
            var replyMessageRequest = new ReplyMessageRequest()
            {
                replyTokens = new List<string>() {
                    replyToken
                }
                ,
                messages = new List<Message>() { imageMapMessages }
            };

            return await messageClient.ReplyMessage(replyMessageRequest);
        }

        public async Task<LineClientResult<ResponseItem>> ReplyMessage(ReplyMessageRequest replyMessageRequest)
        {
            return await messageClient.ReplyMessage(replyMessageRequest);
        }

        #endregion
        #region Profile related

        /// <summary>
        /// Get User Profile
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<Profile>> GetProfile(string userId)
        {
            return await userClient.GetProfile(userId);
        }

        #endregion

        #region Group related

        /// <summary>
        /// Leave group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> LeaveGroup(string groupId)
        {
            return await groupClient.Leave(groupId);
        }

        /// <summary>
        /// Get group member profile
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<Profile>> GetGroupMemberProfile(string userId, string groupId)
        {
            return await groupClient.GetMemberProfile(userId, groupId);
        }

        /// <summary>
        /// Get group member idens
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<MemberIdensResponse>> GetGroupMemberIds(string groupId)
        {
            return await groupClient.GetMemberIds(groupId);
        }

        #endregion

        #region Room related

        /// <summary>
        /// Leave room
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> LeaveRoom(string roomId)
        {
            return await roomClient.Leave(roomId);
        }

        /// <summary>
        /// Get room member profile
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<Profile>> GetRoomMemberProfile(string userId, string roomId)
        {
            return await roomClient.GetMemberProfile(userId, roomId);
        }

        /// <summary>
        /// Get room member idens
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<MemberIdensResponse>> GetRoomMemberIds(string roomId)
        {
            return await roomClient.GetMemberIds(roomId);
        }


        #endregion

        #region Oauth related

        /// <summary>
        /// Issue token
        /// </summary>
        /// <param name="issueTokenRequest"></param>
        /// <returns></returns>
        public async Task<LineClientResult<AccessTokenResponse>> IssueToken(IssueTokenRequest issueTokenRequest) {
            return await authenticateClient.IssueToken(issueTokenRequest);
        }

        /// <summary>
        /// Revoke token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> RevokeToken(string token) {
            return await authenticateClient.RevokeToken(token);
        }

        #endregion

        #region RichMenu

        /// <summary>
        /// Gets a rich menu via a rich menu ID.
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<RichMenu>> GetRichMenu(string richMenuId)
        {
            return await richMenuClient.Get(richMenuId);
        }

        /// <summary>
        /// Creates a rich menu.
        /// </summary>
        /// <param name="richMenu"></param>
        /// <returns></returns>
        public async Task<LineClientResult<RichMenuIdResponse>> CreateRichMenu(RichMenu richMenu)
        {
            return await richMenuClient.Create(richMenu);
        }

        /// <summary>
        /// Deletes a rich menu.
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> DeleteRichMenu(string richMenuId)
        {
            return await richMenuClient.Delete(richMenuId);
        }

        /// <summary>
        /// Gets the ID of the rich menu linked to a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<RichMenuIdResponse>> GetRichMenuByUserId(string userId)
        {
            return await richMenuClient.GetRichMenuByUserId(userId);
        }

        /// <summary>
        /// Links a rich menu to a user. Only one rich menu can be linked to a user at one time.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> LinkRichMenuWithUser(string userId, string richMenuId)
        {
            return await richMenuClient.LinkRichMenuWithUser(userId, richMenuId);
        }

        /// <summary>
        /// Unlinks a rich menu from a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> UnLinkRichMenuWithUser(string userId)
        {
            return await richMenuClient.UnLinkRichMenuWithUser(userId);
        }

        /// <summary>
        /// Gets a list of all uploaded rich menus.
        /// </summary>
        /// <returns></returns>
        public async Task<LineClientResult<RichMenuListResponse>> GetRichMenuList()
        {
            return await richMenuClient.GetRichMenuList();
        }

        /// <summary>
        /// Setup rich menu image
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> SetRichMenuImage(string richMenuId, byte[] image)
        {
            return await richMenuClient.SetRichMenuImage(richMenuId, image);
        }

        /// <summary>
        /// Get rich menu image
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<Stream>> GetRichMenuImage(string richMenuId)
        {
            return await richMenuClient.GetRichMenuImage(richMenuId);
        }
        #endregion
    }
}