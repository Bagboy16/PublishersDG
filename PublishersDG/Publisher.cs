using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishersDG
{
    internal class Publisher
    {
        public string PubId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public string Country { get; set; }

        internal Publisher() { }
        internal Publisher( string pubid, string name, string city, string state, string country)
        {
            PubId = pubid;
            Name = name;
            City = city;
            State = state;
            Country = country;
        }
    }
}
