using LineBotKit.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LineBotKit.Client;

namespace LineBotKit.Simulator.Controllers
{
    /// <summary>
    /// Profile API
    /// </summary>
    [RoutePrefix("api/Profile")]
    public class ProfileController : ApiController
    {
        //public AddressesController(IAddressService addressService)
        //{
        //    _addressService = addressService;
        //}

        /// <summary>
        /// Get user proile
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [Route("Profile"), HttpGet]
        public async Task<Profile> GetProfile(string userId, string token)
        {
            ILineClientManager lineManager = new LineClientManager(token);
            return await lineManager.GetProfile(userId);
        }

        /// <summary>
        /// Get member profile in the group
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="groupId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [Route("GroupMemberProfile"), HttpGet]
        public async Task<Profile> GetGroupMemberProfile(string userId, string groupId, string token)
        {
            ILineClientManager lineManager = new LineClientManager(token);
            return await lineManager.GetGroupMemberProfile(userId, groupId);
        }

        /// <summary>
        /// Get member profile in the room
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roomId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [Route("RoomMemberProfile"), HttpGet]
        public async Task<Profile> GetRoomMemberProfile(string userId, string roomId, string token)
        {
            ILineClientManager lineManager = new LineClientManager(token);
            return await lineManager.GetRoomMemberProfile(userId, roomId);
        }

    }
}
