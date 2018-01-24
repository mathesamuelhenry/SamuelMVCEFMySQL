using EFMVCTestMySQL.DBContext;
using EFMVCTestMySQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using EFMVCTestMySQL.ViewModels;

namespace EFMVCTestMySQL.Controllers
{
    public class MovieController : Controller
    {
        private EFMVCMySqlDBContext _dbContext;

        public MovieController()
        {
            _dbContext = new EFMVCMySqlDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        // GET: Movie
        public ViewResult Index()
        {
            var movieList = _dbContext.Movies.Include(m => m.Genre).ToList();

            return View(movieList);
        }

        public ActionResult Details(int id)
        {
            var movie = _dbContext.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult New()
        {
            var movieViewModel = new MovieFormViewModel
            {
                Genres = _dbContext.Genres.ToList()
            };

            return View("MovieForm", movieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _dbContext.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
                _dbContext.Movies.Add(movie);
            else
            {
                var movieFromDB = _dbContext.Movies.Single(m => m.Id == movie.Id);

                movieFromDB.Name = movie.Name;
                movieFromDB.ReleaseDate = movie.ReleaseDate;
                movieFromDB.GenreId = movie.GenreId;
                movieFromDB.NumberInStock = movie.NumberInStock;
            }

            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Edit(int id)
        {
            var movieInDB = _dbContext.Movies.Include(g => g.Genre).Single(m => m.Id == id);

            var movieViewModel = new MovieFormViewModel(movieInDB)
            {
                Genres = _dbContext.Genres.ToList()
            };

            return View("MovieForm", movieViewModel);
        }
    }
}