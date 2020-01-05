using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MovieData
    {
        [Required]
        public byte Id { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; } = DateTime.Now;

        [Required]
        public int NumberInStock { get; set; }  
    }
}