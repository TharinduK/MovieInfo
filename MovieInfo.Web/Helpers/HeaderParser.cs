using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace MovieInfo.Web.Helpers
{
    public class HeaderParser
    {
        public static PagingInfo FindAndParsePagingInfo(HttpResponseHeaders respHeader )
        {
            //find x-pagination info form http header
            if(respHeader.Contains("x-pagination"))
            {
                var xPageInfo = respHeader.First(ph => ph.Key == "x-pagination").Value;
                return JsonConvert.DeserializeObject<PagingInfo>(xPageInfo.First());
            }
            return null;
        }
    }
}