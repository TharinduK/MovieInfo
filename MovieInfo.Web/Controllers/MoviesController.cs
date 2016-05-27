using Newtonsoft.Json;
using MovieInfo.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MovieInfo.Web.Models;
using PagedList;

namespace MovieInfo.Web.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie
        public async Task<ActionResult> Index(int? page = 1, string search = "")
        {
            var model = new MoviesViewModel();

            var client = MovieInfoHttpClient.GetClient();
            HttpResponseMessage resp = await client.GetAsync(string.Concat("api/movies?search=", search, "&page=", page, "&pagesize=5"));

            if (resp.IsSuccessStatusCode)
            {
                string content = await resp.Content.ReadAsStringAsync();
                var movResponse = JsonConvert.DeserializeObject<IEnumerable<DTO.Movie>>(content);

                var pageInfo = HeaderParser.FindAndParsePagingInfo(resp.Headers);
                var pagedMovList = new StaticPagedList<DTO.Movie>(
                    movResponse,
                    pageInfo.CurrentPageNumber,
                    pageInfo.PageSize,
                    pageInfo.TotalRecordCount);

                model.Movies = pagedMovList;
                model.PagingInfo = pageInfo;

                return View(model);
            }
            else
            {
                return Content("An Error occurred.");
            }
        }
    }
}