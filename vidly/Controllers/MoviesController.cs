using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using System.Data.Entity;
using vidly.ViewModels;
using System.Data.Entity.Validation;


namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext _context;

        public MoviesController()
        {

            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {

            //var movies = _context.Movie.Include(m => m.Genre).ToList();
            //return View(movies);
            return View();
        }

        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Movie= new Movies(),
                Genres = genres
            };

            return View("New", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movies movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    //Movie=movie,
                    Genres = _context.Genres.ToList()
                };

                return View("New", viewModel);
            }
            
            
            if (movie.id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movie.Add(movie);
                
            }
            else
            {
                var movieInDb = _context.Movie.Single(m => m.id == movie.id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            try
            {
                _context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {

                Console.WriteLine(e);
            }
                
           
                
                return RedirectToAction("Index", "Movies");

          
        }

        

       
       public ActionResult Details(int id)
        {
            var movie = _context.Movie.Include(m => m.Genre).SingleOrDefault(m => m.id==id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);

          

        }

       public ActionResult Edit(int id)
       {
           var movie = _context.Movie.SingleOrDefault(c => c.id == id);

           if (movie == null)
               return HttpNotFound();

           var viewModel = new MovieFormViewModel(movie)
           {
               //Movie = movie,
               Genres = _context.Genres.ToList()
           };

           return View("New", viewModel);
       }
      
       

    }

}