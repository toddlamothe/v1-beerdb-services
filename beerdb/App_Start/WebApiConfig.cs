using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace beerdb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GetBreweries",
                routeTemplate: "api/BeerDb/breweries",
                defaults: new { Controller = "BeerDb", Action = "breweries" }
                );

            config.Routes.MapHttpRoute(
                name: "GetBeers",
                routeTemplate: "api/BeerDb/beers",
                defaults: new { Controller = "BeerDb", Action = "beers" }
                );
            config.Routes.MapHttpRoute(
                name: "GetBreweriesByLocation",
                routeTemplate: "api/BeerDb/breweries/near",
                defaults: new { Controller = "BeerDb", Action = "breweriesByLocation" }
                );
            config.Routes.MapHttpRoute(
                name: "GetBreweryLocations",
                routeTemplate: "api/BeerDb/breweries/locations",
                defaults: new { Controller = "BeerDb", Action = "breweryLocations" }
                );
        }
    }
}
