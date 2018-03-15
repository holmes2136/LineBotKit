using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Message
{
    public class LocationMessage : Message
    {
        public string title { get; set; }
        public string address { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }

        public LocationMessage(string title, string address , decimal latitude , decimal longitude)
        {
            this.type = MessageType.Location;
            this.title = title;
            this.address = address;
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}
