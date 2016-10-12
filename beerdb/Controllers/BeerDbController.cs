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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BeerDbController : ApiController
    {
        private const String breweryDbBaseUrl = "http://api.brewerydb.com/v2/";
        private const String breweryDbApiKey = "8ee12a2f196eb183914740dbbb5ccfff";

        [AcceptVerbs("GET")]
        public BrewerySearchResults breweries(String name = null, bool organic = false)
        {
            try
            {
                String urlParameters = "";
                // Brewery name
                if (name != null)
                    urlParameters += "name=" + name;

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

        [AcceptVerbs("GET")]
        public BeerSearchResults beers(String name = null)
        {
            try
            {
                String urlParameters = "";
                // Brewery name
                if (name != null)
                    urlParameters += "name=" + name;

                // http://api.brewerydb.com/v2/beers?key=8ee12a2f196eb183914740dbbb5ccfff&name=The%20Alchemist
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(breweryDbBaseUrl);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = httpClient.GetAsync("beers?key=" + breweryDbApiKey + "&" + urlParameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    var dataObject = response.Content.ReadAsAsync<BeerSearchResults>().Result;
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
