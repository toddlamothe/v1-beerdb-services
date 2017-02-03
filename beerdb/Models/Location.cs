using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beerdb.Models
{
    public class Location
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        public String locality { get; set; }
        public String region { get; set; }
        public String postalCode { get; set; }
        public String isPrimary { get; set; }
        public LocationCountry country { get; set; }

    }
}
