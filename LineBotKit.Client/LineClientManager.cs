﻿using LineBotKit.Common.Model;
using LineBotKit.Common.Model.Message;
using LineBotKit.Common.Model.RichMenu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
        public RichMenuClient richMenuClient { get; set; }

        public LineClientManager(string ChannelAccessToken)
        {
            this._ChannelAccessToken = ChannelAccessToken;
            this.messageClient = new MessageClient(ChannelAccessToken);
            this.userClient = new UserClient(ChannelAccessToken);
            this.groupClient = new GroupClient(ChannelAccessToken);
            this.roomClient = new RoomClient(ChannelAccessToken);
            this.richMenuClient = new RichMenuClient(ChannelAccessToken);
        }

        public MessageClient GetMessageClient()
        {
            return this.messageClient;
        }

        #region Send message realted

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
            Uri _originalContentUrl = new Uri(originalContentUrl);

            var pushMessageRequest = new PushMessageRequest()
            {
                to = to,
                messages = new List<Message>() {
                      new AudioMessage(_originalContentUrl.AbsoluteUri,duration)
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
        public async Task<ResponseItem> PushVideoMessage(string to, string originalContentUrl, string previewImageUrl)
        {
            Uri _originalContentUrl = new Uri(originalContentUrl);
            Uri _previewImageUrl = new Uri(previewImageUrl);

            var pushMessageRequest = new PushMessageRequest()
            {
                to = to,
                messages = new List<Message>() {
                      new VideoMessage(_originalContentUrl.AbsoluteUri,_previewImageUrl.AbsoluteUri)
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
        public async Task<ResponseItem> PushLocationMessage(string to, string title, string address , decimal latitude , decimal longitude)
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

        public async Task<ResponseItem> PushMessage(PushMessageRequest pushMessageRequest)
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
        public Stream GetMessageContent(string messageId) {
            return  messageClient.GetMessageContent(messageId);
        }

        #endregion

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

        public async Task<MemberIdensResponse> GetGroupMemberIds(string groupId)
        {
            return await groupClient.GetMemberIds(groupId);
        }

        public async Task<MemberIdensResponse> GetRoomMemberIds(string roomId)
        {
            return await roomClient.GetMemberIds(roomId);
        }

        #region RichMenu

        /// <summary>
        /// Gets a rich menu via a rich menu ID.
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        public async Task<RichMenu> GetRichMenu(string richMenuId)
        {
            return await richMenuClient.Get(richMenuId);
        }

        /// <summary>
        /// Creates a rich menu.
        /// </summary>
        /// <param name="richMenu"></param>
        /// <returns></returns>
        public async Task<RichMenuIdResponse> CreateRichMenu(RichMenu richMenu)
        {
            return await richMenuClient.Create(richMenu);
        }

        /// <summary>
        /// Deletes a rich menu.
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        public async Task<ResponseItem> DeleteRichMenu(string richMenuId)
        {
            return await richMenuClient.Delete(richMenuId);
        }

        /// <summary>
        /// Gets the ID of the rich menu linked to a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<RichMenuIdResponse> GetRichMenuByUserId(string userId)
        {
            return await richMenuClient.GetRichMenuByUserId(userId);
        }

        /// <summary>
        /// Links a rich menu to a user. Only one rich menu can be linked to a user at one time.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        public async Task<ResponseItem> LinkRichMenuWithUser(string userId, string richMenuId)
        {
            return await richMenuClient.LinkRichMenuWithUser(userId, richMenuId);
        }

        /// <summary>
        /// Unlinks a rich menu from a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ResponseItem> UnLinkRichMenuWithUser(string userId)
        {
            return await richMenuClient.UnLinkRichMenuWithUser(userId);
        }

        /// <summary>
        /// Gets a list of all uploaded rich menus.
        /// </summary>
        /// <returns></returns>
        public async Task<RichMenuListResponse> GetRichMenuList()
        {
            return await richMenuClient.GetRichMenuList();
        }

        /// <summary>
        /// Downloads an image associated with a rich menu.
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        public  Stream GetRichMenuImage(string richMenuId) {
            return richMenuClient.GetRichMenuImage(richMenuId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        public async Task<ResponseItem> SetRichMenuImage(string richMenuId , Stream imageStream)
        {
            return await richMenuClient.SetRichMenuImage(richMenuId, imageStream);
        }

        #endregion
    }
}
