using System.Collections.Generic;

namespace LineBotKit.WebAPI.Model
{
    public interface IQueryStringParameterCollection : IList<KeyValuePair<string, string>>
    {
        void Add(string key, string value);
    }
}