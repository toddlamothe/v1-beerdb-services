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
                String urlParameters = "&withLocations=Y";
                // Brewery name
                if (name != null)
                    urlParameters += "&name=" + name;

                // http://api.brewerydb.com/v2/breweries?key=8ee12a2f196eb183914740dbbb5ccfff&name=The%20Alchemist%20&withLocations=Y&hasImages=Y
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(breweryDbBaseUrl);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = httpClient.GetAsync("breweries?key=" + breweryDbApiKey + urlParameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    var dataObject = response.Content.ReadAsAsync<BrewerySearchResults>().Result;
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

        // breweries/near/
        [AcceptVerbs("GET")]
        public BrewerySearchResults breweriesByLocation(String lat = null, String lon = null, String radius = "10", string city = null, String state = null, String zip = null)
        {
            try
            {
                String urlParameters = "&withSocialAccounts=Y&unit=mi";
                urlParameters += "&radius=" + radius;
                if (lat != null)
                    urlParameters += "&lat=" + lat;
                if (lon != null)
                    urlParameters += "&lng=" + lon;
                if (city != null)
                    urlParameters += "&locality=" + city;
                if (state != null)
                    urlParameters += "&region=" + state;
                if (zip != null)
                    urlParameters += "&postalCode=" + zip;

                // http://api.brewerydb.com/v2/breweries?key=8ee12a2f196eb183914740dbbb5ccfff&name=The%20Alchemist%20&withLocations=Y&hasImages=Y
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(breweryDbBaseUrl);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = httpClient.GetAsync("search/geo/point?key=" + breweryDbApiKey + urlParameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    var dataObject = response.Content.ReadAsAsync<BreweryLocationSearchResults>().Result;
                    BrewerySearchResults brewerySearchResults = new BrewerySearchResults();
                    brewerySearchResults.currentPage = dataObject.currentPage;
                    brewerySearchResults.numberOfPages = dataObject.numberOfPages;
                    brewerySearchResults.totalResults = dataObject.totalResults;
                    brewerySearchResults.data = new List<BreweryData>();

                    // Iterate through the data object and build a BrewerySearchResults data object
                    for (int x = 0; x < dataObject.totalResults; x++)
                    {
                        // For each brewery location returned, transform to a standard BrewerySearchResults object
                        BreweryLocationData breweryLocationData = dataObject.data[x];

                        //BreweryData breweryData = breweryLocationData.brewery;
                        BreweryData breweryData = new BreweryData();
                        breweryData.id = breweryLocationData.id;
                        breweryData.name = breweryLocationData.brewery.name;
                        breweryData.description = breweryLocationData.brewery.description;
                        breweryData.nameShortDisplay = breweryLocationData.brewery.nameShortDisplay;
                        breweryData.website = breweryLocationData.brewery.website;
                        breweryData.established = breweryLocationData.brewery.established;
                        breweryData.isOrganic = breweryLocationData.brewery.isOrganic;
                        breweryData.images = breweryLocationData.brewery.images;
                        breweryData.status = breweryLocationData.brewery.status;
                        breweryData.statusDisplay = breweryLocationData.brewery.statusDisplay;
                        breweryData.createDate = breweryLocationData.brewery.createDate;
                        breweryData.updateDate = breweryLocationData.brewery.updateDate;
                        var breweryLocation = new BreweryLocation();
                        breweryLocation.latitude = breweryLocationData.latitude;
                        breweryLocation.longitude = breweryLocationData.longitude;
                        breweryLocation.isPrimary = breweryLocationData.isPrimary;
                        breweryLocation.name = breweryLocationData.name;
                        breweryLocation.streetAddress = breweryLocationData.streetAddress;
                        breweryLocation.locationTypeDisplay = breweryLocationData.locationTypeDisplay;
                        breweryLocation.locationType = breweryLocationData.locationType;
                        breweryLocation.locality = breweryLocationData.locality;
                        breweryLocation.region = breweryLocationData.region;
                        breweryLocation.postalCode = breweryLocationData.postalCode;
                        breweryData.locations = new List<BreweryLocation>();
                        breweryData.locations.Add(breweryLocation);
                        brewerySearchResults.data.Add(breweryData);
                    }
                    return brewerySearchResults;
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
        public BrewerySearchResults breweryLocations(String city = null, String state = null, String zip = null)
        {
            try
            {
                String urlParameters = "";
                if (city != null)
                    urlParameters += "&locality=" + city;
                if (state != null)
                    urlParameters += "&region=" + state;
                if (zip != null)
                    urlParameters += "&postalCode=" + zip;

                // http://api.brewerydb.com/v2/breweries?key=8ee12a2f196eb183914740dbbb5ccfff&name=The%20Alchemist%20&withLocations=Y&hasImages=Y
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(breweryDbBaseUrl);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = httpClient.GetAsync("locations?key=" + breweryDbApiKey + urlParameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    var dataObject = response.Content.ReadAsAsync<BreweryLocationSearchResults>().Result;
                    BrewerySearchResults brewerySearchResults = new BrewerySearchResults();
                    brewerySearchResults.currentPage = dataObject.currentPage;
                    brewerySearchResults.numberOfPages = dataObject.numberOfPages;
                    brewerySearchResults.totalResults = dataObject.totalResults;
                    brewerySearchResults.data = new List<BreweryData>();

                    // Iterate through the data object and build a BrewerySearchResults data object
                    for (int x = 0; x < dataObject.data.Count; x++)
                    {
                        // For each brewery location returned, transform to a standard BrewerySearchResults object
                        BreweryLocationData breweryLocationData = dataObject.data[x];
                        BreweryData breweryData = new BreweryData();
                        breweryData.id = breweryLocationData.id;
                        breweryData.name = breweryLocationData.brewery.name;
                        breweryData.description = breweryLocationData.brewery.description;
                        breweryData.nameShortDisplay = breweryLocationData.brewery.nameShortDisplay;
                        breweryData.website = breweryLocationData.brewery.website;
                        breweryData.established = breweryLocationData.brewery.established;
                        breweryData.isOrganic = breweryLocationData.brewery.isOrganic;
                        breweryData.images = breweryLocationData.brewery.images;
                        breweryData.status = breweryLocationData.brewery.status;
                        breweryData.statusDisplay = breweryLocationData.brewery.statusDisplay;
                        breweryData.createDate = breweryLocationData.brewery.createDate;
                        breweryData.updateDate = breweryLocationData.brewery.updateDate;
                        var breweryLocation = new BreweryLocation();
                        breweryLocation.latitude = breweryLocationData.latitude;
                        breweryLocation.longitude = breweryLocationData.longitude;
                        breweryLocation.isPrimary = breweryLocationData.isPrimary;
                        breweryLocation.name = breweryLocationData.name;
                        breweryLocation.streetAddress = breweryLocationData.streetAddress;
                        breweryLocation.locationTypeDisplay = breweryLocationData.locationTypeDisplay;
                        breweryLocation.locationType = breweryLocationData.locationType;
                        breweryLocation.locality = breweryLocationData.locality;
                        breweryLocation.region = breweryLocationData.region;
                        breweryLocation.postalCode = breweryLocationData.postalCode;
                        breweryData.locations = new List<BreweryLocation>();
                        breweryData.locations.Add(breweryLocation);
                        brewerySearchResults.data.Add(breweryData);
                    }
                    return brewerySearchResults;
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

                HttpResponseMessage response = httpClient.GetAsync("beers?key=" + breweryDbApiKey + "&withBreweries=Y&" + urlParameters).Result;
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
