using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace PlaceMyBet.Models
{
    public class ApuestaRepository
    {
        private MySqlConnection Connect()
        {

            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;Password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;

        }

        internal ApuestaDTO Retrieve()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM Apuesta";
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO a = null;

                if (res.Read())
                {

                    Debug.WriteLine("Recuperado: " + res.GetDouble(1) + res.GetString(2) + res.GetDouble(3) + res.GetString(4) + res.GetInt16(5) + res.GetString(6));
                    a = new ApuestaDTO(res.GetDouble(1), res.GetString(2), res.GetDouble(3), res.GetString(4), res.GetInt16(5), res.GetString(6));
                }
                con.Close();
                return a;
            }
            catch (MySqlException a)
            {

                Debug.WriteLine("Se ha producido un error de conexión");
                return null;

            }
        }


        internal double RetrieveCuotas(ApuestaDTO apuesta)
        {


            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            if (apuesta.TipoApuesta == "Over")
            {
                command.CommandText = " SELECT  CuotaOver FROM Mercado WHERE ID = '" + apuesta.IDMercado + "';";

            }

            else if (apuesta.TipoApuesta == "Under")
            {
      
                command.CommandText = " SELECT  CuotaUnder FROM Mercado WHERE ID = '" + apuesta.IDMercado + "';";

            }


            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                double cuota = 0;

                if (res.Read())
                {
                    cuota = res.GetDouble(0);

                }
                return cuota;
            }
            catch (MySqlException a)
            {

                Debug.WriteLine("Se ha producido un error de conexión");
                return 0;

            }
        }


        internal void Save(ApuestaDTO apuesta, double cuota)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();







                con.Open();
                command.CommandText = "INSERT INTO apuesta(DineroApostado, TipoApuesta, Cuota, ID_Mercado, Email_Usuario) VALUES('" + apuesta.DineroApostado + "','" + apuesta.TipoApuesta + "','" + cuota.ToString(CultureInfo.CreateSpecificCulture("us-US")) + "','" + apuesta.IDMercado + "','" + apuesta.EmailUsuario + "');";
                Debug.WriteLine("Comando: " + command.CommandText);
                command.ExecuteNonQuery();


                con.Close();
            




        }
    }




    }