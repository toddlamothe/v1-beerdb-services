using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using beerdb.Models;
using System.Web.Http.Cors;

namespace beerdb.Controllers
{
    [EnableCors(origins: "http://localhost:8000", headers: "*", methods: "*")]
    public class BeerDbController : ApiController
    {
        private const String breweryDbBaseUrl = "http://api.brewerydb.com/v2/";
        private const String breweryDbApiKey = "8ee12a2f196eb183914740dbbb5ccfff";

        // Mock payload used for testing
        BrewerySearchResults _breweries = new BrewerySearchResults {
            currentPage = 1,
            numberOfPages = 1,
            totalResults = 1,
            status = "success",
            data = new List<BreweryData> {
                new BreweryData {
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
                    images = new BreweryImages
                    {
                        icon = "https://s3.amazonaws.com/brewerydbapi/brewery/pj4HJk/upload_rtxgwR-icon.png",
                        medium = "https://s3.amazonaws.com/brewerydbapi/brewery/pj4HJk/upload_rtxgwR-medium.png",
                        large = "https://s3.amazonaws.com/brewerydbapi/brewery/pj4HJk/upload_rtxgwR-large.png",
                        squareMedium = "https://s3.amazonaws.com/brewerydbapi/brewery/pj4HJk/upload_rtxgwR-squareMedium.png",
                        squareLarge = "https://s3.amazonaws.com/brewerydbapi/brewery/pj4HJk/upload_rtxgwR-squareLarge.png"
                    }
                }
            }
        };

        [AcceptVerbs("GET")]
        public BrewerySearchResults breweries()
        {
            try
            {
                String urlParameters = "name=The%20Alchemist";
                // "breweries?key=" + breweryDbApiKey + "&" + urlParameters
                // http://api.brewerydb.com/v2/breweries?key=8ee12a2f196eb183914740dbbb5ccfff&name=The%20Alchemist
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(breweryDbBaseUrl);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = httpClient.GetAsync("breweries?key=" + breweryDbApiKey + "&" + urlParameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    var dataObject = response.Content.ReadAsAsync<BrewerySearchResults>().Result;
                    Console.WriteLine("Data Object: ", dataObject);
                    return dataObject;
                }
                else
                {
                    throw new Exception("Error retrieving results");
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                throw e;
            }
        }
    }
}
