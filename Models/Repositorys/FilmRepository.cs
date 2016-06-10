using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using System.Configuration;

namespace WebsiteIMDB.Models.Repositorys
{
    public class FilmRepository
    {

        public static IEnumerable<FilmData> LaadFilms()
        {
            string query = "SELECT M.MOVIEID, M.MOVIENAME, M.RELEASEDATE, M.RATING FROM MOVIE M";
            List<FilmData> films = new List<FilmData>();
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
                                films.Add(new FilmData(Convert.ToInt32(reader["MOVIEID"]), reader["MOVIENAME"].ToString(),Convert.ToDateTime( reader["RELEASEDATE"]),Convert.ToDouble( reader["RATING"])));
                            }
                        }
                    }
                }
            }
            catch (OracleException)
            {

            }
            return films;
        }
    }
}