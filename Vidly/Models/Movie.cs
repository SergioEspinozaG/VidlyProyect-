using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter a movie's name.")]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        public byte MovieDataId { get; set; }

        [ForeignKey("MovieDataId")]
        public MovieData MovieData { get; set; }
    }
}