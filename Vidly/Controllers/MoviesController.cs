using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DataAccess;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly Data data;

        public MoviesController()
        {
            data = new Data();   
        }

        // GET: Movies
        public ActionResult Random()
        {

            var vm = new RandomMovieViewModel();
            vm.Customers = data.GetCustomers();
            vm.Movies = data.GetMovies();

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
    }
}