using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieInfo;


namespace MovieInfo.BLL
{
    public class MovieInfoManager
    {
        public MovieInfoManager()
        {
        }

        public MovieInfoManager(DAL.IMovieRepository repository)
        {
            _MovieRepository = repository;
        }

        private DAL.IMovieRepository _MovieRepository = null;

        public IEnumerable<DTO.Movie> GetMovieSummary(string searchKeyword="")
        {
            DAL.IMovieRepository movieRepository = _MovieRepository ?? new DAL.MovieRepository();
            List<DTO.Movie> results = new List<DTO.Movie>();
            var movieList = movieRepository.GetMovieSummary(searchKeyword);
            if (movieList != null)
            {
                foreach (var m in movieList)
                {
                    results.Add(new DTO.Movie
                    {
                        Title = m.Name,
                        Year = m.Year.HasValue ? m.Year.Value.Year : DateTime.MinValue.Year,
                        Genre = (DTO.Genres)m.Genre,
                        Description = m.Description
                    });
                }
            }
            return results;
        }
    }
}
