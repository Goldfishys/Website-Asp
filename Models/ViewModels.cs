using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteIMDB.Models
{
    public class ViewModels
    {
        public List<PersonData> Persons { get; set; }
        public List<FilmData> films { get; set; }
        public List<string> sorted { get; set; }

        public ViewModels(List<FilmData> films, List<string> sorted)
        {
            this.films = films;
            this.sorted = sorted;
        }
        public ViewModels(List<PersonData> Persons, List<string> sorted)
        {
            this.Persons = Persons;
            this.sorted = sorted;
        }
    }
}