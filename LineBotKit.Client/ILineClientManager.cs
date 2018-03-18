using LineBotKit.Common.Model;
using LineBotKit.Common.Model.Message;
using LineBotKit.Common.Model.RichMenu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public interface ILineClientManager
    {
        #region Send message related

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

        /// <summary>
        /// Send video message
        /// </summary>
        /// <param name="to"></param>
        /// <param name="originalContentUrl">URL of video file (Max: 1000 characters) ,HTTPS,mp4,Max: 1 minute,Max: 10 MB</param>
        /// <param name="previewImageUrl">URL of preview image (Max: 1000 characters),HTTPS,JPEG,Max: 240 x 240,Max: 1 MB</param>
        /// <returns></returns>
        Task<ResponseItem> PushVideoMessage(string to, string originalContentUrl, string previewImageUrl);

        /// <summary>
        /// Send location message
        /// </summary>
        /// <param name="to"></param>
        /// <param name="title"></param>
        /// <param name="address"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        Task<ResponseItem> PushLocationMessage(string to, string title, string address, decimal latitude, decimal longitude);

        Task<ResponseItem> PushMessage(PushMessageRequest pushMessageRequest);

        /// <summary>
        /// Gets image, video, and audio data sent by users.
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        Stream GetMessageContent(string messageId);

        Task<ResponseItem> MulticastMessage(List<string> to, List<Message> messages);

        #endregion

        #region Reply message related

        Task<ResponseItem> ReplyTextMessage(string to, string message);

        Task<ResponseItem> ReplyImageMessage(string to, string imageContentUrl, string imagePreviewUrl);

        Task<ResponseItem> ReplyStickerMessage(string to, int packageId, int stickerId);

        Task<ResponseItem> ReplyMessage(ReplyMessageRequest reply);

        #endregion

        #region Profile related

        Task<Profile> GetProfile(string userId);

        #endregion

        #region Group related

        Task<ResponseItem> LeaveGroup(string groupId);

        Task<Profile> GetGroupMemberProfile(string userId, string groupId);

        Task<MemberIdensResponse> GetGroupMemberIds(string groupId);

        #endregion

        #region Room related

        Task<Profile> GetRoomMemberProfile(string userId, string groupId);

        Task<MemberIdensResponse> GetRoomMemberIds(string roomId);

        #endregion

        #region Rich Menu

        /// <summary>
        /// Gets a rich menu via a rich menu ID.
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        Task<RichMenu> GetRichMenu(string richMenuId);

        /// <summary>
        /// Creates a rich menu.
        /// </summary>
        /// <param name="richMenu"></param>
        /// <returns></returns>
        Task<RichMenuIdResponse> CreateRichMenu(RichMenu richMenu);

        /// <summary>
        /// Deletes a rich menu.
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        Task<ResponseItem> DeleteRichMenu(string richMenuId);

        /// <summary>
        /// Gets the ID of the rich menu linked to a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<RichMenuIdResponse> GetRichMenuByUserId(string userId);

        /// <summary>
        /// Links a rich menu to a user. Only one rich menu can be linked to a user at one time.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        Task<ResponseItem> LinkRichMenuWithUser(string userId, string richMenuId);

        /// <summary>
        /// Unlinks a rich menu from a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ResponseItem> UnLinkRichMenuWithUser(string userId);

        /// <summary>
        /// Gets a list of all uploaded rich menus.
        /// </summary>
        /// <returns></returns>
        Task<RichMenuListResponse> GetRichMenuList();

        /// <summary>
        /// Downloads an image associated with a rich menu.
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        Stream GetRichMenuImage(string richMenuId);

        Task<ResponseItem> SetRichMenuImage(string richMenuId , Stream imageStream);

        #endregion

    }
}
