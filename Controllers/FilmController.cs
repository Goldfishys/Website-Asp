using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteIMDB.Models;
using WebsiteIMDB.Models.Repositorys;

namespace WebsiteIMDB.Controllers
{
    public class FilmController : Controller
    {
        // GET: Film
        public ActionResult Index(string Case)
        {
            List<FilmData> films = FilmRepository.LaadFilms().ToList();
            List<string> sorted = new List<string>(new List<string> { "TAsc", "RDateDesc", "RatingDesc" });
            switch (Case)
            {
                case "RatingAsc":
                    films = films.OrderBy(x => x.Rating).ToList();
                    sorted[2] = "RatingDesc";
                    break;
                case "RatingDesc":
                    films = films.OrderByDescending(x => x.Rating).ToList();
                    sorted[2] = "RatingAsc";
                    break;
                case "TAsc":
                    films = films.OrderBy(x => x.Titel).ToList();
                    sorted[0] = "TDesc";
                    break;
                case "TDesc":
                    films = films.OrderByDescending(x => x.Titel).ToList();
                    sorted[0] = "TAsc";
                    break;
                case "RDateAsc":
                    films = films.OrderBy(x => x.ReleaseDate).ToList();
                    sorted[1] = "RDateDesc";
                    break;
                case "RDateDesc":
                    films = films.OrderByDescending(x => x.ReleaseDate).ToList();
                    sorted[1] = "RDateAsc";
                    break;
            }

            return View(new ViewModels(films, sorted));
        }

        public ActionResult NewFilm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewFilm(FilmData f)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {
                return View(f);
            }
        }
    }
}