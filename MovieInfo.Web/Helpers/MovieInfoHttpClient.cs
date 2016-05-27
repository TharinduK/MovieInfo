using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MovieInfo.Web.Helpers
{
    public static  class MovieInfoHttpClient
    {
        public static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(MovieInfo.Web.Properties.Settings.Default.APIAddress);
            
            //Accept responses only on json format            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}