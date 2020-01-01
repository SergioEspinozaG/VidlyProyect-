using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DataAccess
{
    public class Data
    {
        public List<Movie> GetMovies()
        {
            return getMovies();
        }

        public List<Customer> GetCustomers()
        {
            return getCustomers();
        }

        private List<Movie> getMovies()
        {
            var movies = new List<Movie>
            {
                new Movie{ Id = 101, Name = "John Wick"},
                new Movie{ Id = 201, Name = "Jumanji"}
            };

            return movies;
        }

        private List<Customer> getCustomers()
        {
            var customer = new List<Customer>
            {
                new Customer{ Id = 20150108, Name = "Sergio Espinoza"},
                new Customer{ Id = 20150706, Name = "Daniela Herrera"}
            };

            return customer;
        }
    }
}