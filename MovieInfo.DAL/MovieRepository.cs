using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieInfo;
using MovieInfo.DAL.EntityModel;

namespace MovieInfo.DAL
{
    public class MovieRepository : IMovieRepository
    {
        private MovieDBEntities _ctx;

        public MovieRepository()
        {
            _ctx = new MovieDBEntities();
        }
        public MovieRepository(MovieDBEntities ctx)
        {
            if (ctx == null)
            {
                _ctx = new MovieDBEntities();
            }
            else
            {
                _ctx = ctx;
            }
        }

        public IEnumerable<Movie> GetMovieSummary(string searchKeyword = "")
        {
            if (string.IsNullOrEmpty(searchKeyword))
            {
                return _ctx.Movies1.ToList();
            }
            else
            {
                var movSummaryList = from m in _ctx.Movies1
                                     where m.Description.Contains(searchKeyword) || m.Name.Contains(searchKeyword)
                                     select m;

                return movSummaryList.ToList();
            }
        }
    }
}
