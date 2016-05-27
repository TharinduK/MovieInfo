using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieInfo.DTO;
using PagedList;

namespace MovieInfo.Web.Models
{
    public class MoviesViewModel
    {
        public IPagedList<Movie> Movies { get; set; }

        public Helpers.PagingInfo PagingInfo { get; set; }
    }
}