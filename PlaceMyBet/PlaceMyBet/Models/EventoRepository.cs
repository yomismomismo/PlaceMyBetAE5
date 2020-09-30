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

            private MySqlConnection Connect()
            {

                string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;Password=;SslMode=none";
                MySqlConnection con = new MySqlConnection(connString);
                return con;

            }
            internal Evento Retrieve()
            {

                MySqlConnection con = Connect();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "SELECT * FROM Evento";

                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Evento e = null;

                if (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + res.GetString(1) + res.GetString(2) + res.GetString(3) + res.GetInt32(4));
                    e = new Evento(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetString(3), res.GetInt32(4));
                }


                return e;

            }
        }
    }
