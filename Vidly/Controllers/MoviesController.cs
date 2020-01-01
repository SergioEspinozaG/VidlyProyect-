using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {

            var vm = new RandomMovieViewModel();
            vm.Customers = GetCustomers();
            vm.Movies = GetMovies();

            return View(vm);
        }

        public ActionResult Edit(int Id)
        {
            return Content("Id = " + Id);
        }

        //movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(string.Format($"pageIndex={pageIndex}&sortBy={sortBy}"));
        }

        [Route("movies/realeased/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByRealeaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Customers()
        {
            return View();
        }

        private List<Movie> GetMovies()
        {
            var movies = new List<Movie>
            {
                new Movie{ Id = 101, Name = "John Wick"},
                new Movie{ Id = 201, Name = "Jumanji"}
            };

            return movies;
        }

        private List<Customer> GetCustomers()
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