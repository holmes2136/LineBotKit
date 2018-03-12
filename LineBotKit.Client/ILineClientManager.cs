﻿using LineBotKit.Common.Model;
using LineBotKit.Common.Model.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public interface ILineClientManager
    {
        Task<ResponseItem> PushTextMessage(string to , string message);

        Task<ResponseItem> PushImageMessage(string to, string imageContentUrl, string imagePreviewUrl);

        Task<ResponseItem> PushStickerMessage(string to, int packageId, int stickerId);

        /// <summary>
        /// Send audio message
        /// </summary>
        /// <param name="to"></param>
        /// <param name="originalContentUrl">URL of audio file (Max: 1000 characters),HTTPS,m4a,Max: 1 minute,Max: 10 MB</param>
        /// <param name="duration">Length of audio file (milliseconds)</param>
        /// <returns></returns>
        Task<ResponseItem> PushAudioMessage(string to, string originalContentUrl, int duration);

        Task<ResponseItem> PushMessage(PushMessageRequest pushMessageRequest);

        Task<ResponseItem> ReplyTextMessage(string to, string message);

        Task<ResponseItem> ReplyImageMessage(string to, string imageContentUrl, string imagePreviewUrl);

        Task<ResponseItem> ReplyStickerMessage(string to, int packageId, int stickerId);

        Task<ResponseItem> ReplyMessage(ReplyMessageRequest reply);

        Task<ResponseItem> MulticastAsync(List<string> to, List<Message> messages);

        Task<Profile> GetProfile(string userId);

        Task<ResponseItem> LeaveGroup(string groupId);

        Task<Profile> GetGroupMemberProfile(string userId, string groupId);

        Task<Profile> GetRoomMemberProfile(string userId, string groupId);

        Task<ResponseItem> GetGroupMemberIds(string groupId);

        Task<ResponseItem> GetRoomMemberIds(string roomId);


    }
}
