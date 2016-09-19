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

        [AcceptVerbs("GET")]
        public BrewerySearchResults breweries(String name = null, bool organic = false)
        {
            try
            {
                Console.WriteLine("");
                if (name != null)
                {
                    Console.WriteLine("  brewery name = ", name);
                }
                Console.WriteLine("");
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
