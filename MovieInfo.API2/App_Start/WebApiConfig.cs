using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace MovieInfo.API2
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register()
        {
            var config = new HttpConfiguration();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json-patch+json"));
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            return config;
        }
    }
}
