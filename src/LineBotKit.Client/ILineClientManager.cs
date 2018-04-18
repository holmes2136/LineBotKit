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
    public interface ILineClientManager
    {
        #region Send message related

        Task<LineClientResult<ResponseItem>> PushTextMessage(string to, string message);
        Task<LineClientResult<ResponseItem>> PushImageMessage(string to, string imageContentUrl, string imagePreviewUrl);
        Task<LineClientResult<ResponseItem>> PushStickerMessage(string to, int packageId, int stickerId);
        Task<LineClientResult<ResponseItem>> PushAudioMessage(string to, string originalContentUrl, int duration);
        Task<LineClientResult<ResponseItem>> PushVideoMessage(string to, string originalContentUrl, string previewImageUrl);
        Task<LineClientResult<ResponseItem>> PushLocationMessage(string to, string title, string address, decimal latitude, decimal longitude);
        Task<LineClientResult<ResponseItem>> PushMessage(PushMessageRequest pushMessageRequest);
        Task<LineClientResult<ResponseItem>> MulticastMessage(List<string> to, List<Message> messages);

        #endregion

        #region Reply message related

        Task<LineClientResult<ResponseItem>> ReplyTextMessage(string replyToken, string message);
        Task<LineClientResult<ResponseItem>> ReplyImageMessage(string to, string imageContentUrl, string imagePreviewUrl);
        Task<LineClientResult<ResponseItem>> ReplyStickerMessage(string to, int packageId, int stickerId);
        Task<LineClientResult<ResponseItem>> ReplyAudioMessage(string replyToken, string to, string originalContentUrl, int duration);
        Task<LineClientResult<ResponseItem>> ReplyVideoMessage(string replyToken, string to, string originalContentUrl, string previewImageUrl);
        Task<LineClientResult<ResponseItem>> ReplyLocationMessage(string replyToken, string to, string title, string address, decimal latitude, decimal longitude);
        Task<LineClientResult<ResponseItem>> ReplyImageMapMessage(string replyToken, string to, ImageMapMessage imageMapMessages);
        Task<LineClientResult<ResponseItem>> ReplyMessage(ReplyMessageRequest reply);

        #endregion

        Task<LineClientResult<Stream>> GetMessageContent(string messageId);
        Task<LineClientResult<Profile>> GetProfile(string userId);

        #region Oauth related

        Task<LineClientResult<AccessTokenResponse>> IssueToken(IssueTokenRequest issueTokenRequest);
        Task<LineClientResult<ResponseItem>> RevokeToken(string token);

        #endregion

        #region Rich Menu

        Task<LineClientResult<RichMenu>> GetRichMenu(string richMenuId);
        Task<LineClientResult<RichMenuIdResponse>> CreateRichMenu(RichMenu richMenu);
        Task<LineClientResult<ResponseItem>> DeleteRichMenu(string richMenuId);
        Task<LineClientResult<RichMenuIdResponse>> GetRichMenuByUserId(string userId);
        Task<LineClientResult<ResponseItem>> LinkRichMenuWithUser(string userId, string richMenuId);
        Task<LineClientResult<ResponseItem>> UnLinkRichMenuWithUser(string userId);
        Task<LineClientResult<RichMenuListResponse>> GetRichMenuList();
        Task<LineClientResult<ResponseItem>> SetRichMenuImage(string richMenuId, byte[] image);
        Task<LineClientResult<Stream>> GetRichMenuImage(string richMenuId);
        #endregion

        #region Group related

        Task<LineClientResult<ResponseItem>> LeaveGroup(string groupId);
        Task<LineClientResult<Profile>> GetGroupMemberProfile(string userId, string groupId);
        Task<LineClientResult<MemberIdensResponse>> GetGroupMemberIds(string groupId);

        #endregion

        #region Room related

        Task<LineClientResult<ResponseItem>> LeaveRoom(string roomId);
        Task<LineClientResult<Profile>> GetRoomMemberProfile(string userId, string groupId);
        Task<LineClientResult<MemberIdensResponse>> GetRoomMemberIds(string roomId);

        #endregion
    }
}
