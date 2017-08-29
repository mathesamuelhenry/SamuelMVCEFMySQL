using EFMVCTestMySQL.DBContext;
using EFMVCTestMySQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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
    }
}