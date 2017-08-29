using EFMVCTestMySQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFMVCTestMySQL.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ViewResult Index()
        {
            var movieList = new List<Movie>
            {
                new Movie { Id = 1, Name = "Hangover" },
                new Movie { Id = 2, Name = "Die Hard" }
            };

            return View(movieList);
        }
    }
}