using LineBotKit.Client.Request;
using LineBotKit.Client.Response;
using LinetBotKit.Common.Model;
using LinetBotKit.Common.Model.RichMenu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public class RichMenuClient : Request.LineClientBase, IRichMenuClient
    {
        public RichMenuClient(string channelAccessToken) : base(channelAccessToken) { }

        /// <summary>
        /// Gets a rich menu via a rich menu ID.
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<RichMenu>> Get(string richMenuId)
        {
            if (string.IsNullOrEmpty(richMenuId))
            {
                throw new ArgumentException("The property rich menu iden can't not be null");
            }

            var request = new LineGetRequest<RichMenu>(this, $"bot/richmenu/{richMenuId}");

            return await request.Execute();
        }

        /// <summary>
        /// Creates a rich menu.
        /// </summary>
        /// <param name="richMenu"></param>
        /// <returns></returns>
        public async Task<LineClientResult<RichMenuIdResponse>> Create(RichMenu richMenu)
        {
            if (richMenu == null)
            {
                throw new ArgumentNullException(nameof(RichMenu));
            }

            var request = new LinePostRequest<RichMenuIdResponse>(this, $"bot/richmenu");

            return await request.Execute(richMenu);
        }

        /// <summary>
        /// Deletes a rich menu.
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> Delete(string richMenuId)
        {
            if (string.IsNullOrEmpty(richMenuId))
            {
                throw new ArgumentException("The property rich menu iden can't not be null");
            }

            var request = new LineDeleteRequest<ResponseItem>(this, $"bot/richmenu/{richMenuId}");

            return await request.Execute();
        }

        /// <summary>
        /// Gets the ID of the rich menu linked to a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<RichMenuIdResponse>> GetRichMenuByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("The property user iden can't not be null");
            }

            var request = new LineGetRequest<RichMenuIdResponse>(this, $"bot/user/{userId}/richmenu");

            return await request.Execute();
        }

        /// <summary>
        /// Links a rich menu to a user. Only one rich menu can be linked to a user at one time.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> LinkRichMenuWithUser(string userId, string richMenuId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("The property user iden can't not be null");
            }

            if (string.IsNullOrEmpty(richMenuId))
            {
                throw new ArgumentException("The property rich menu iden can't not be null");
            }

            var request = new LinePostRequest<ResponseItem>(this, $"bot/user/{userId}/richmenu/{richMenuId}");

            return await request.Execute(null);
        }

        /// <summary>
        /// Unlinks a rich menu from a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> UnLinkRichMenuWithUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("The property user iden can't not be null");
            }

            var request = new LineDeleteRequest<ResponseItem>(this, $"bot/user/{userId}/richmenu");

            return await request.Execute();
        }

        /// <summary>
        /// Gets a list of all uploaded rich menus.
        /// </summary>
        /// <returns></returns>
        public async Task<LineClientResult<RichMenuListResponse>> GetRichMenuList()
        {
            var request = new LineGetRequest<RichMenuListResponse>(this, $"bot/richmenu/list");

            return await request.Execute();
        }

        /// <summary>
        /// Uploads and attaches an image to a rich menu.
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <param name="imageStream"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> SetRichMenuImage(string richMenuId, Byte[] image)
        {
            if (string.IsNullOrEmpty(richMenuId))
            {
                throw new ArgumentException("The property rich menu iden can't not be null");
            }

            var request = new LinePostByteContentRequest<ResponseItem>(this, $"bot/richmenu/{richMenuId}/content");

            return await request.Execute(image);
        }


        /// <summary>
        /// Downloads an image associated with a rich menu.
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<Stream>> GetRichMenuImage(string richMenuId)
        {
            if (string.IsNullOrEmpty(richMenuId))
            {
                throw new ArgumentException("The property rich menu iden can't not be null");
            }

            var request = new LineGetStreamRequest<Stream>(this, $"bot/richmenu/{richMenuId}/content");

            return await request.Execute();
        }
    }
}
