using LineBotKit.Client.Response;
using LinetBotKit.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public interface IGroupClient
    {
        Task<LineClientResult<ResponseItem>> Leave(string groupId);
        Task<LineClientResult<Profile>> GetMemberProfile(string userId, string groupId);
        Task<LineClientResult<MemberIdensResponse>> GetMemberIds(string groupId);
    }
}
