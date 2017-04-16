using MovieLibrary.Models;
using System.Collections.Generic;

namespace MovieLibrary.ViewModel
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public string Title
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                    return "Edit Movie";
                else
                    return "New Movie";
            }
        }
    }
}