using LineBotKit.Client;
using LineBotKit.Common.Model;
using LineBotKit.Common.Model.Message;
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
    /// Group API
    /// </summary>
    [RoutePrefix("api/Group")]
    public class GroupController : ApiController
    {

        /// <summary>
        /// Leave group
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [Route("Leave"), HttpPost]
        public async Task<ResponseItem> Leave(string groupId, string token)
        {
            ILineClientManager lineManager = new LineClientManager(token);
            return await lineManager.LeaveGroup(groupId);
        }

        /// <summary>
        /// Get member iden in the group , 
        /// Only available for LINE@ Approved accounts or official accounts.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [Route("GroupMemberIds"), HttpGet]
        public async Task<ResponseItem> GetGroupMemberIds(string groupId, string token)
        {
            ILineClientManager lineManager = new LineClientManager(token);
            return await lineManager.GetGroupMemberIds(groupId);
        }
    }
}
