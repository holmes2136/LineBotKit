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
    public interface IRichMenuClient
    {
        /// <summary>
        /// Get rich menu by rich menu iden
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        Task<LineClientResult<RichMenu>> Get(string richMenuId);

        /// <summary>
        /// Create rich menu
        /// </summary>
        /// <param name="richMenu"></param>
        /// <returns></returns>
        Task<LineClientResult<RichMenuIdResponse>> Create(RichMenu richMenu);

        /// <summary>
        /// Delete rich menu
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        Task<LineClientResult<ResponseItem>> Delete(string richMenuId);

        /// <summary>
        /// Gets the ID of the rich menu linked to a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<LineClientResult<RichMenuIdResponse>> GetRichMenuByUserId(string userId);

        /// <summary>
        /// Links a rich menu to a user. Only one rich menu can be linked to a user at one time.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        Task<LineClientResult<ResponseItem>> LinkRichMenuWithUser(string userId, string richMenuId);

        /// <summary>
        /// Unlinks a rich menu from a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<LineClientResult<ResponseItem>> UnLinkRichMenuWithUser(string userId);

        /// <summary>
        /// Gets a list of all uploaded rich menus.
        /// </summary>
        /// <returns></returns>
        Task<LineClientResult<RichMenuListResponse>> GetRichMenuList();

        /// <summary>
        /// Setup rich menu image
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        Task<LineClientResult<ResponseItem>> SetRichMenuImage(string richMenuId, Byte[] image);

        /// <summary>
        /// Get the rich menu image
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        Task<LineClientResult<Stream>> GetRichMenuImage(string richMenuId);
    }
}
