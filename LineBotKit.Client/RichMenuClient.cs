using LineBotKit.Common.Model;
using LineBotKit.Common.Model.RichMenu;
using LineBotKit.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public class RichMenuClient:ClientBase,IRichMenuClient
    {
        public RichMenuClient(string _ChannelAccessToken)
        {
            this.ChannelAccessToken = _ChannelAccessToken;
        }

        /// <summary>
        /// Gets a rich menu via a rich menu ID.
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        public async Task<RichMenu> Get(string richMenuId)
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Get, $"bot/richmenu/{richMenuId}");
            request.Authorization = this.ChannelAccessToken;
            return await ExecuteApiCallAsync<RichMenu>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a rich menu.
        /// </summary>
        /// <param name="richMenu"></param>
        /// <returns></returns>
        public async Task<RichMenuIdResponse> Create(RichMenu richMenu)
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Post, "bot/richmenu", richMenu);
            request.Authorization = this.ChannelAccessToken;
            return await ExecuteApiCallAsync<RichMenuIdResponse>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes a rich menu.
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        public async Task<ResponseItem> Delete(string richMenuId)
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Delete, $"bot/richmenu/{richMenuId}");
            request.Authorization = this.ChannelAccessToken;
            return await ExecuteApiCallAsync<ResponseItem>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the ID of the rich menu linked to a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<RichMenuIdResponse> GetRichMenuByUserId(string userId)
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Get, $"bot/user/{userId}/richmenu");
            request.Authorization = this.ChannelAccessToken;
            return await ExecuteApiCallAsync<RichMenuIdResponse>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Links a rich menu to a user. Only one rich menu can be linked to a user at one time.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        public async Task<ResponseItem> LinkRichMenuWithUser(string userId,string richMenuId)
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Post, $"bot/user/{userId}/richmenu/{richMenuId}");
            request.Authorization = this.ChannelAccessToken;
            return await ExecuteApiCallAsync<ResponseItem>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Unlinks a rich menu from a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ResponseItem> UnLinkRichMenuWithUser(string userId)
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Delete, $"bot/user/{userId}/richmenu");
            request.Authorization = this.ChannelAccessToken;
            return await ExecuteApiCallAsync<ResponseItem>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a list of all uploaded rich menus.
        /// </summary>
        /// <returns></returns>
        public async Task<RichMenuListResponse> GetRichMenuList()
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Get, "bot/richmenu/list");
            request.Authorization = this.ChannelAccessToken;
            return await ExecuteApiCallAsync<RichMenuListResponse>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Downloads an image associated with a rich menu.
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        public Stream GetRichMenuImage(string richMenuId)
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Get, $"bot/richmenu/{richMenuId}/content");
            request.Authorization = this.ChannelAccessToken;
            return ExecuteStreamServiceCall(request);
        }

        /// <summary>
        /// Uploads and attaches an image to a rich menu.
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <param name="imageStream"></param>
        /// <returns></returns>
        public async Task<ResponseItem> SetRichMenuImage(string richMenuId, Stream imageStream)
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Post, $"bot/richmenu/{richMenuId}/content");
            request.Authorization = this.ChannelAccessToken;
            request.Content = new StreamContent(imageStream);
            return await ExecuteApiCallAsync<ResponseItem>(request).ConfigureAwait(false);
        }
    }
}
