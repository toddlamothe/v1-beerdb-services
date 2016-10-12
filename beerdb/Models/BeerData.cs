using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beerdb.Models
{
    public class BeerData
    {
        public String id { get; set; }
        public String name { get; set; }
        public String nameDisplay { get; set; }
        public String description { get; set; }
        public String abv { get; set; }
        public String ibu { get; set; }
        public string status { get; set; }
        public BeerLabels labels{ get; set; }
    }
}