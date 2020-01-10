using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class MovieData
    {
        [Required]
        public byte Id { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; } = DateTime.Now;

        [Required]
        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

        [Display(Name = "Age Restriction")]
        public int AgeRestriction { get; set; }

        [Required]
        public MoviesGenres MoviesGenres { get; set; }

        public byte GenreId { get; set; }
    }
}