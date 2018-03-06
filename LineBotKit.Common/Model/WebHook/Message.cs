using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.WebHook
{
    public class Message
    {
        public string type
        {
            get;
            set;
        }

        public string id
        {
            get;
            set;
        }

        public string fileName
        {
            get;
            set;
        }

        public string fileSize
        {
            get;
            set;
        }

        public string text
        {
            get;
            set;
        }

        public string title
        {
            get;
            set;
        }

        public string address
        {
            get;
            set;
        }

        public double latitude
        {
            get;
            set;
        }

        public double longitude
        {
            get;
            set;
        }

        public int packageId
        {
            get;
            set;
        }

        public int stickerId
        {
            get;
            set;
        }
    }
}
