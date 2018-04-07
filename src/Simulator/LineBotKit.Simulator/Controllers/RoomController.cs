using LineBotKit.Client;
using LineBotKit.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LineBotKit.Simulator.Controllers
{
    /// <summary>
    /// Room API
    /// </summary>
    [RoutePrefix("api/Room")]
    public class RoomController : ApiController
    {
        /// <summary>
        /// Get member iden in the room , 
        /// Only available for LINE@ Approved accounts or official accounts.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [Route("RoomMemberIds"), HttpGet]
        public async Task<MemberIdensResponse> GetRoomMemberIds(string roomId, string token)
        {
            ILineClientManager lineManager = new LineClientManager(token);
            return await lineManager.GetRoomMemberIds(roomId);
        }
    }
}
