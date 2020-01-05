
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MoviesGenres
    {
        [Required]
        public byte Id { get; set; }

        public string GenreName { get; set; }

        public string  Description { get; set; }
    }
}