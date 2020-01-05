using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public MovieData MovieData { get; set; }

        public byte MovieDataId { get; set; }
    }
}