using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beerdb.Models
{
    public class Location
    {
        public float lat { get; set; }
        public float lon { get; set; }
        public String locality { get; set; }
        public String regiod { get; set; }
        public String postalCode { get; set; }
 
    }
}
