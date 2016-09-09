using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using beerdb.Models;

namespace beerdb.Controllers
{
    public class BeerDbController : ApiController
    {
        Brewery[] _breweries = new Brewery[] {
            new Brewery { totalResults = 1 }
        };

        [AcceptVerbs("GET")]
        public IEnumerable<Brewery> breweries()
        {
            return _breweries;
        }
    }
}
