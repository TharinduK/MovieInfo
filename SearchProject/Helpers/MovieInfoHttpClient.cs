using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace MovieInfo.Web.Helpers
{
    public static  class MovieInfoHttpClient
    {
        public static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8244/");
#warning this needs to come from constantas 
            //clear all the headers that we are accepting by default
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}