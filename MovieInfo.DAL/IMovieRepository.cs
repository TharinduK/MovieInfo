using System.Collections.Generic;

namespace MovieInfo.DAL
{
    public interface IMovieRepository
    {
        IEnumerable<EntityModel.Movie> GetMovieSummary(string searchKeyword="");
    }
}