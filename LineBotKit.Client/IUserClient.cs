using LineBotKit.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public interface IUserClient
    {

          Task<Profile> GetProfile(string userId);
    }
}
