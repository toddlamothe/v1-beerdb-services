using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beerdb.Models
{
    public class BrewerySearchResults
    {
        public int currentPage { get; set; }
        public int numberOfPages { get; set; }
        public int totalResults { get; set; }
        public BreweryData data {get; set; }
        public String status { get; set; }
}
}