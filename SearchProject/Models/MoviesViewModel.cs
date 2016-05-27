using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieInfo.DTO;

namespace MovieInfo.Web.Models
{
    public class MoviesViewModel
    {
        public IEnumerable<Movie> Moview { get; set; }
    }
}