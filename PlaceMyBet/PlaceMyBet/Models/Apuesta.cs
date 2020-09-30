using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta
    {
        public Apuesta(int apuestaID, double dineroApostado, string tipoApuesta, double cuota, string fecha, int iDMercado, string emailUsuario)
        {
            ApuestaID = apuestaID;
            DineroApostado = dineroApostado;
            TipoApuesta = tipoApuesta;
            this.cuota = cuota;
            Fecha = fecha;
            IDMercado = iDMercado;
            EmailUsuario = emailUsuario;
        }

        public int ApuestaID { get; set; }
        public double DineroApostado { get; set; }
        public string TipoApuesta { get; set; }
        public double cuota { get; set; }
        public string Fecha { get; set; }
        public int IDMercado { get; set; }
        public string EmailUsuario { get; set; }

    }
}