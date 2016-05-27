using Newtonsoft.Json;
using MovieInfo.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MovieInfo.Web.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public async Task<ActionResult> Index()
        {
            var client = MovieInfoHttpClient.GetClient();

            HttpResponseMessage resp = await client.GetAsync("api/search");

            if (resp.IsSuccessStatusCode)
            {
                string content = await resp.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject(content);

                return View(model);
            }
            else
            {
                return Content("An Error occurred.");
            }
        }
    }
}