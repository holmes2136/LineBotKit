using LineBotKit.Common.Model;
using LineBotKit.Common.Model.RichMenu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        Task<RichMenu> Get(string richMenuId);

        /// <summary>
        /// Create rich menu
        /// </summary>
        /// <param name="richMenu"></param>
        /// <returns></returns>
        Task<RichMenuIdResponse> Create(RichMenu richMenu);

        /// <summary>
        /// Delete rich menu
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <returns></returns>
        Task<ResponseItem> Delete(string richMenuId);

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

        Task<ResponseItem> SetRichMenuImage(string richMenuId, Stream imageStream);
    }
}
