using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteIMDB.Models;
using WebsiteIMDB.Models.Repositorys;

namespace WebsiteIMDB.Controllers
{
    public class PersonsController : Controller
    {
        // GET: Persons
        public ActionResult Index(string Case)
        {
            List<PersonData> persons = PersoonRepository.LaadPersons().ToList();
            List<string> sorted = new List<string>( new List<string> {"vnAsc", "anAsc" });

            switch (Case)
            {
                case "vnAsc":
                    persons = persons.OrderBy(x => x.Voornaam).ToList();
                    sorted[0] = "vnDesc";
                    break;
                case "vnDesc":
                    persons = persons.OrderByDescending(x => x.Voornaam).ToList();
                    sorted[0] = "vnAsc";
                    break;
                case "anAsc":
                    persons = persons.OrderBy(x => x.Achternaam).ToList();
                    sorted[1] = "anDesc";
                    break;
                case "anDesc":
                    persons = persons.OrderByDescending(x => x.Achternaam).ToList();
                    sorted[1] = "anAsc";
                    break;
            }
            return View(new ViewModels(persons, sorted));
        }
    }
}