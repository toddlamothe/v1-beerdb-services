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
        Brewery brewery = new Brewery { totalResults = 1 };

        public Brewery getBrewery()
        {
            return brewery;
        }
    }
}
