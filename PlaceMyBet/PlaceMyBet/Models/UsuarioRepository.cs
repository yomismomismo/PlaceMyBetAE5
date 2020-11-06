using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace PlaceMyBet.Models
{
    public class UsuarioRepository
    {

       /* private MySqlConnection Connect()
        {

            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;Password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;

        }*/

        internal Usuario Retrieve()
        {

            /* MySqlConnection con = Connect();
             MySqlCommand command = con.CreateCommand();
             command.CommandText = "SELECT * FROM Usuario";

             con.Open();
             MySqlDataReader res = command.ExecuteReader();

             Usuario u = null;

             if (res.Read())
             {

                 Debug.WriteLine("Recuperado: " + res.GetString(0) + res.GetString(1) + res.GetString(2) + res.GetInt16(3));
                 u = new Usuario(res.GetString(0), res.GetString(1), res.GetString(2), res.GetInt16(3));

             }
             return u;*/
            return null;
        }

    }
}