using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beerdb.Models
{
    public class BreweryLocationData
    {
        public String id { get; set; }
        public String name { get; set; }
        public String streetAddress { get; set; }
        public String locality { get; set; }
        public String region { get; set; }
        public String postalCode { get; set; }
        public String latitude { get; set; }
        public String longitude { get; set; }
        public String isPrimary { get; set; }
        public String inPlanning { get; set; }
        public String isClosed { get; set; }
        public String openToPublic { get; set; }
        public String locationType { get; set; }
        public String locationTypeDisplay { get; set; }
        public String countryIsoCode { get; set; }
        public String status { get; set; }
        public String statusDisplay { get; set; }
        public String createDate { get; set; }
        public String updateDate { get; set; }
        public String breweryId { get; set; }
        public BreweryData brewery { get; set; }
        public LocationCountry country { get; set; }
        public long distance { get; set; }
    }
}