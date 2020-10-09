using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Evento
    {
        public Evento(string eventoID, string equipo_Local, string equipo_Visitante, string fecha, string goles)
        {
            EventoID = eventoID;
            Equipo_Local = equipo_Local;
            Equipo_Visitante = equipo_Visitante;
            Fecha = fecha;
            Goles = goles;
        }

        public string EventoID { get; set; }
        public string Equipo_Local { get; set; }
        public string Equipo_Visitante { get; set; }
        public string Fecha { get; set; }
        public string Goles { get; set; }


    }


    public class EventoDTO
    {

        public EventoDTO(string equipo_Local, string equipo_Visitante, string fecha)
        {
            Equipo_Local = equipo_Local;
            Equipo_Visitante = equipo_Visitante;
            Fecha = fecha;
        }


        public string Equipo_Local { get; set; }
        public string Equipo_Visitante { get; set; }
        public string Fecha { get; set; }


    }

}

