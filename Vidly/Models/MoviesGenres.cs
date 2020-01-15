
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MoviesGenres
    {
        [Display(Name = "Genre")]
        public byte Id { get; set; }

        [Display(Name = "Genre Type")]
        public string GenreName { get; set; }

        [Display(Name = "Genre Description")]
        public string  Description { get; set; }
    }
}