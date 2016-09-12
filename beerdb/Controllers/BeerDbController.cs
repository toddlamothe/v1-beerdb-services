using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using beerdb.Models;
using System.Web.Http.Cors;

namespace beerdb.Controllers
{
    [EnableCors(origins: "http://localhost:8000", headers: "*", methods: "*")]
    public class BeerDbController : ApiController
    {

        // Mock payload used for testing
        BrewerySearchResults _breweries = new BrewerySearchResults {
            currentPage = 1,
            numberOfPages = 1,
            totalResults = 1,
            status = "success",
            data = new BreweryData {
                id = "pj4HJk",
                name = "The Alchemist",
                nameShortDisplay = "The Alchemist",
                description = "The Alchemist is a 7 barrel brew pub specializing in hand-crafted  beer and casual pub fare.  All of our ales flow directly from our  basement brewery, which was designed and installed by our brewer and  co-proprietor John Kimmich.   We use only the finest imported malts and  domestic hops available to bring you the tastiest and finest selection  of beers in Vermont!",
                website = "http://www.alchemistbeer.com/",
                established = "1976",
                isOrganic = "N",
                status = "verified",
                statusDisplay = "Verified",
                createDate = "2012-01-03 02:42:09",
                updateDate = "2015-12-22 15:00:03",
                images = new BreweryImages {
                    icon = "https://s3.amazonaws.com/brewerydbapi/brewery/pj4HJk/upload_rtxgwR-icon.png",
                    medium = "https://s3.amazonaws.com/brewerydbapi/brewery/pj4HJk/upload_rtxgwR-medium.png",
                    large = "https://s3.amazonaws.com/brewerydbapi/brewery/pj4HJk/upload_rtxgwR-large.png",
                    squareMedium = "https://s3.amazonaws.com/brewerydbapi/brewery/pj4HJk/upload_rtxgwR-squareMedium.png",
                    squareLarge = "https://s3.amazonaws.com/brewerydbapi/brewery/pj4HJk/upload_rtxgwR-squareLarge.png"
                }
            }
        };

        [AcceptVerbs("GET")]
        public BrewerySearchResults breweries()
        {
            try
            {
                return _breweries;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
