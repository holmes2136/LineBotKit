using System;
using System.Collections.Generic;
using System.Text;

namespace LinetBotKit.Common.Model.Extensions
{
    public static class UriExtensions
    {
        /// <summary>
        /// Validate uri is valid or not
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static Uri ValidateUrl(this Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentException("The url property can't be null");
            }
            else if (uri.ToString().Length > 1000)
            {
                throw new ArgumentException("The url property can't be bigger than 1000 characters");
            }
            else if (!uri.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("The url property need to use the https");
            }
            return uri;
        }
    }
}
