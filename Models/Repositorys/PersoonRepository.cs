using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using System.Configuration;

namespace WebsiteIMDB.Models.Repositorys
{
    public class PersoonRepository
    {
        public static IEnumerable<PersonData> LaadPersons()
        {
            string query = "SELECT PERSONID, NAME, LASTNAME FROM PERSON";
            List<PersonData> Persons = new List<PersonData>();
            try
            {
                using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnection"].ToString()))
                {
                    conn.Open();
                    using (OracleCommand command = new OracleCommand(query, conn))
                    {
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Persons.Add(new PersonData(Convert.ToInt32(reader["PERSONID"]), reader["NAME"].ToString(), reader["LASTNAME"].ToString()));
                            }
                        }
                    }
                }
            }
            catch (OracleException)
            {

            }
            return Persons;
        }
    }
}