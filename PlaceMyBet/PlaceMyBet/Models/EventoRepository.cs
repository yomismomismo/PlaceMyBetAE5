using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Web;
using MySql.Data.MySqlClient;

    namespace PlaceMyBet.Models
    {
        public class EventoRepository
        {

          /*  private MySqlConnection Connect()
            {

                string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;Password=;SslMode=none";
                MySqlConnection con = new MySqlConnection(connString);
                return con;

            }*/
            internal List<Evento> RetrieveList()
            {
            List<Evento> evento = new List<Evento>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                evento = context.Eventos.ToList();
            }
            /* MySqlConnection con = Connect();
             MySqlCommand command = con.CreateCommand();
             command.CommandText = "SELECT * FROM Evento";

             con.Open();
             MySqlDataReader res = command.ExecuteReader();

             EventoDTO e = null;

             if (res.Read())
             {
                 Debug.WriteLine("Recuperado: " + res.GetString(1) + res.GetString(2) + res.GetString(3));
                 e = new EventoDTO(res.GetString(1), res.GetString(2), res.GetString(3));
             }*/


            //return e;
            return evento;

            }

        internal void Save(Evento e)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Eventos.Add(e);
            context.SaveChanges();

        }
    }
    }
