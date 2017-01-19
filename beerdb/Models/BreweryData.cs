using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beerdb.Models
{
    public class BreweryData
    {
        public String id { get; set; }
        public String name { get; set; }
        public String nameShortDisplay { get; set; }
        public String description { get; set; }
        public String website { get; set; }
        public String established { get; set; }
        public String isOrganic { get; set; }
        public BreweryImages images { get; set; }
        public String status { get; set; }
        public String statusDisplay { get; set; }
        public String createDate { get; set; }
        public String updateDate { get; set; }
        public List<BreweryLocation> locations { get; set; }

    }
}