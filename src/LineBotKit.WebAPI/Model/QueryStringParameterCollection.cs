using System.Collections.Generic;

namespace LineBotKit.WebAPI.Model
{
    public class QueryStringParameterCollection : List<KeyValuePair<string, string>>, IQueryStringParameterCollection
    {
        public void Add(string key, string value)
        {
            this.Add(new KeyValuePair<string, string>(key, value));
        }
    }
}
