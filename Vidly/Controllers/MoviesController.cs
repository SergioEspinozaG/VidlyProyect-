using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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
           var movies = _context.Movies.Include(m => m.MovieData.MoviesGenres).ToList();
            
            return View(movies);
        }


        public ViewResult MoviesDetail(int Id)
        {
            var moviesDetailt = _context.Movies.Include(m => m.MovieData.MoviesGenres).SingleOrDefault(movies => movies.Id == Id);

            return View(moviesDetailt);
        }

        public ActionResult NewMovie()
        {
            var movieData = _context.MoviesGenres.ToList();

            var newMovie = new MoviesFormViewModel()
            {
                MoviesGenrese    = movieData,
            };

            return View("MovieForm", newMovie);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Include(m => m.MovieData.MoviesGenres).Single(c => c.Id == movie.Id);
                
                movieInDb.Name = movie.Name;
                movieInDb.MovieData.AgeRestriction = movie.MovieData.AgeRestriction;
                movieInDb.MovieData.NumberInStock = movie.MovieData.NumberInStock;
                movieInDb.MovieData.GenreId = movie.MovieData.GenreId;
                movieInDb.MovieData.AgeRestriction = movie.MovieData.AgeRestriction;
                movieInDb.MovieData.ReleaseDate = movie.MovieData.ReleaseDate;

            }

            _context.SaveChanges();

            return RedirectToAction("Movies", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movieEdit = _context.Movies.Include(m => m.MovieData.MoviesGenres).Single(m => m.Id == id);

            if (movieEdit == null)
            {
                return HttpNotFound();
            }

            var vm = new MoviesFormViewModel()
            {
                Movie = movieEdit,
                MoviesGenrese = _context.MoviesGenres.ToList(),
            };

            return View("MovieForm", vm);
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