using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beerdb.Models
{
    public class BreweryLocation : Location
    {
        public String name { get; set; }
        public String streetAddress { get; set; }
        public String phone { get; set; }
        public String locationTypeDisplay { get; set; }
        public String locationType { get; set; }
    }
}