using System;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public byte GenreId { get; set; }

        public byte NumberInStock { get; set; }
    }
}