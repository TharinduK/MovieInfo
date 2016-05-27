using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.DTO
{
    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }

        public Genres Genre { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
    }
}
