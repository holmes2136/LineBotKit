using LineBotKit.Client.Response;
using LinetBotKit.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public interface IRoomClient
    {
        Task<LineClientResult<ResponseItem>> Leave(string roomId);
        Task<LineClientResult<Profile>> GetMemberProfile(string userId, string roomId);
        Task<LineClientResult<MemberIdensResponse>> GetMemberIds(string roomId);
    }
}
