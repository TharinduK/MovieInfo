using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;

namespace MovieInfo.API.Controllers
{
    //[EnableCors("*","*","GET,POST")]
    public class MoviesController : ApiController
    {
        private BLL.MovieInfoManager _movMgr;
        private const int MAX_PAGE_SIZE = 20;

        public MoviesController()
        {
            _movMgr = new BLL.MovieInfoManager();
        }

        public MoviesController(BLL.MovieInfoManager movieMgr)
        {
            _movMgr = movieMgr ?? new BLL.MovieInfoManager();
        }

        [HttpGet]
        [Route("api/movies", Name = "MovieList")]//give a name to route
        public IHttpActionResult Get(int page = 1, int pageSize = 10, string search="")
        {
            try
            {
                var keywords = System.Web.HttpUtility.HtmlDecode(search);
                var movList = _movMgr.GetMovieSummary(keywords);

                #region Pagination Logic

                //ensure that the page size is not more than max
                pageSize = pageSize > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : pageSize;

                //calculate the count for pagination metadata
                var totalRecCount = movList.Count();
                var totalPages = (int)Math.Ceiling((double)totalRecCount / pageSize);

                //setup previous and next page links
                var urlHelper = new UrlHelper(Request);
                var prevLink = page > 1 ? urlHelper.Link(
                    "MovieList",
                    new { page = page - 1, pageSize = pageSize, }) : "";
                var nextLink = page < totalPages ? urlHelper.Link(
                    "MovieList",
                    new { page = page + 1, pageSize = pageSize, }) : "";

                //setup pagination header info
                var paginationHeader = new
                {
                    currentPageNumber = page,
                    pageSize = pageSize,
                    totalRecordCount = totalRecCount,
                    totalPageCount = totalPages,
                    previousPageLink = prevLink,
                    nextPageLink = nextLink
                };

                //convert pagination info to json and add to response header 
                HttpContext.Current.Response.Headers.Add("x-pagination",
                 JsonConvert.SerializeObject(paginationHeader));
                #endregion

                return Ok(movList
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
