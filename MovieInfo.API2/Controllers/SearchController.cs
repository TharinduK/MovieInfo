using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieInfo.API2.Controllers
{
    public class SearchController : ApiController
    {
        private BLL.MovieInfoManager _movMgr;

        public SearchController()
        {
            _movMgr = new BLL.MovieInfoManager();
        }

        public SearchController(BLL.MovieInfoManager movieMgr)
        {
            _movMgr = movieMgr ?? new BLL.MovieInfoManager();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var movList = _movMgr.GetAll();

                return Ok(movList);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
