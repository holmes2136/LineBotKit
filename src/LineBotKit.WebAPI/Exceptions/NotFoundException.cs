using System;
using System.Runtime.Serialization;

namespace LineBotKit.WebAPI.Exceptions
{
    /// <summary>
    /// Exception for record not found
    /// </summary>
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}
