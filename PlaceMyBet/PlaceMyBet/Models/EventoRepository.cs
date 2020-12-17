using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Web;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;

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
            internal List<EventoDTO> RetrieveList()
            {
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                List<EventoDTO> eventos = context.Eventos.Select(p => ToDTO(p)).ToList();
                return eventos;
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

        }
        
        /*** Ejercicio 1 ***/
        internal List<Mercado> apuestaEvento(string nombre)
        {

            List<Mercado> evento;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                evento = context.Mercados
                    .Include(e=> e.Evento)
                    .Include(a => a.Apuestas)
                    .Where(e => e.Evento.Equipo_Local == nombre || e.Evento.Equipo_Visitante == nombre)
                    .ToList();
                return evento;
            }
            /*** Fin Ejercicio 1 ***/
        }
        internal void updateDinero(int id, Evento evento)
        {

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                var newEvent = context.Eventos
                    .Where(b => b.EventoID == id)
                    .FirstOrDefault();

                if (evento.Equipo_Local != null)
                {
                    newEvent.Equipo_Local = evento.Equipo_Local;
                }

                if (evento.Equipo_Visitante != null)
                {
                    newEvent.Equipo_Visitante = evento.Equipo_Visitante;
                }
                context.SaveChanges();
            }
        }
        internal void DeleteEvento(int id)
        {

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                var removeEvent = context.Eventos
                    .Where(b => b.EventoID == id)
                    .FirstOrDefault();

                context.Eventos.Remove(removeEvent);
                context.SaveChanges();
            }
        }
        internal static EventoDTO ToDTO(Evento e)
        {
            return new EventoDTO(e.Equipo_Local, e.Equipo_Visitante, e.Fecha);
        }
        internal void Save(Evento e)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Eventos.Add(e);
            context.SaveChanges();

        }
    }
    }
