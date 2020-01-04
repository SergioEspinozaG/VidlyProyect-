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

        private readonly RandomMovieViewModel vm;

        public MoviesController()
        {
            data = new Data();
            vm = new RandomMovieViewModel();
        }

        // GET: Movies
        public ActionResult Movies()
        {

            vm.Customers = data.GetCustomers();
            vm.Movies = data.GetMovies();

            return View(vm);
        }


        public ActionResult MoviesDetail(int Id)
        {
            vm.Movies = data.GetMovies().Where(m => m.Id == Id).ToList();

            return Content("Id = " + Id);
        }

        public ActionResult Edit(int Id)
        {
            return View(vm);
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