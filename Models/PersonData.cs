using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteIMDB.Models
{
    public class PersonData
    {
        public int ID { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }

        public PersonData( int ID, string Voornaam, string Achternaam)
        {
            this.ID = ID;
            this.Voornaam = Voornaam;
            this.Achternaam = Achternaam;
        }
    }
}