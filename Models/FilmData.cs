using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteIMDB.Models
{
    public class FilmData
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        public string Titel { get; set; }


        [Required(ErrorMessage = "Dit veld is verplicht")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        public string Omschrijving { get; set; }
        public string PhotoPath { get; set; }

        [Required(ErrorMessage = "Selecteer minimaal 1 Genre")]
        public string[] Genres { get; set; }

        public FilmData(int ID, string Titel,DateTime ReleaseDate, double Rating)
        {
            this.ID = ID;
            this.Titel = Titel;
            this.ReleaseDate = ReleaseDate;
            this.Rating = Rating;
        }

        public FilmData()
        {

        }
    }
}