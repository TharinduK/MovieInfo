using MovieInfo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieInfo;

namespace MovieInfoWeb.Controllers
{
    public class SearchController : ApiController
    {

        public IHttpActionResult Get()
        {
            try
            {
                MovieInfo.BLL.MovieInfoManager movMgr = new MovieInfo.BLL.MovieInfoManager();
                var movList = movMgr.GetAll();

                ////TODO: just for testing
                //List<Movie> results = new List<Movie>();
                //results.Add(new Movie { Title = "Matrix", Genre = Genres.Action, Year = 2000 });
                //results.Add(new Movie { Title = "New Year", Genre = Genres.Comedy, Year = 2001 });
                //results.Add(new Movie { Title = "Dora", Genre = Genres.Cartoon, Year = 2010 });

                return Ok(movList);
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }
    }
}
