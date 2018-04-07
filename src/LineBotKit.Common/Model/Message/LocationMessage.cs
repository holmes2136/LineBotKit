using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Common.Model.Message
{
    public class LocationMessage : Message
    {
        public override MessageType type => MessageType.Location;
        private string _title;
        private string _address;
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }

        public LocationMessage(string title, string address, decimal latitude, decimal longitude)
        {
            this.Title = title;
            this.Address = address;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        /// <summary>
        /// title
        /// </summary>
        [JsonProperty("title")]
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("The title property can't be null or whitespace");

                if (value.Length > 100)
                    throw new ArgumentException("The title can't be bigger than 100 characters");

                _title = value;
            }
        }

        /// <summary>
        /// address
        /// </summary>
        [JsonProperty("address")]
        public string Address
        {
            get
            {
                return _address;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("The address property can't be null or whitespace");

                if (value.Length > 100)
                    throw new ArgumentException("The address property can't be bigger than 100 characters");

                _address = value;
            }
        }
    }
}
