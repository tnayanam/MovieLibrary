﻿using MovieLibrary.Models;
using System.Collections.Generic;

namespace MovieLibrary.ViewModel
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}