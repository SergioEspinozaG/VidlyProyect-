using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MyDBContext _context;

        public MoviesController()
        {
           _context = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Movies()
        {
           var movies = _context.Movies.Include(m => m.MovieData).ToList();

            return View(movies);
        }


        public ViewResult MoviesDetail(int Id)
        {
            var moviesDetailt = _context.Movies.Include(m=>m.MovieData).SingleOrDefault(movies => movies.Id == Id);

            return View(moviesDetailt);
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

    }
}