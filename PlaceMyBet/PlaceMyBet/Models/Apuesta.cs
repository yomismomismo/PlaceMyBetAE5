using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta
    {


        public int ApuestaID { get; set; }
        public double DineroApostado { get; set; }
        public string TipoApuesta { get; set; }
        public double Cuota { get; set; }
        public DateTime Fecha { get; set; }
        public int MercadoID { get; set; }
        public Mercado Mercado { get; set; }
        public string UsuarioEmail { get; set; }
        public Usuario Usuario { get; set; }

        public Apuesta(int apuestaID, double dineroApostado, string tipoApuesta, double cuota, DateTime fecha, int mercadoID, string usuarioEmail)
        {
            ApuestaID = apuestaID;
            DineroApostado = dineroApostado;
            TipoApuesta = tipoApuesta;
            Cuota = cuota;
            Fecha = fecha;
            MercadoID = mercadoID;
            UsuarioEmail = usuarioEmail;
        }
    }

    public class ApuestaDTO
    {
        public ApuestaDTO(double dineroApostado, string tipoApuesta, double cuota, int iDmercado, string usuarioEmail)
        {
            DineroApostado = dineroApostado;
            TipoApuesta = tipoApuesta;
            Cuota = cuota;
            IDmercado = iDmercado;
            UsuarioEmail = usuarioEmail;
        }

        public double DineroApostado { get; set; }
        public string TipoApuesta { get; set; }
        public double Cuota { get; set; }
        public int IDmercado { get; set; }
        public string UsuarioEmail { get; set; }


    }

    public class ApuestaUser
    {
        public ApuestaUser(int evento, string tipoApuesta, double cuota, double dineroapostado)
        {
            Evento = evento;
            TipoApuesta = tipoApuesta;
            Cuota = cuota;
            Dineroapostado = dineroapostado;
        }


        public int Evento { get; set; }
        public string TipoApuesta { get; set; }
        public double Cuota { get; set; }
        public double Dineroapostado { get; set; }

    }
    public class ApuestaMercado
    {
        public ApuestaMercado(int tipo_Mercado, string tipoApuesta, double cuota, double dineroapostado)
        {
            this.tipo_Mercado = tipo_Mercado;
            TipoApuesta = tipoApuesta;
            Cuota = cuota;
            Dineroapostado = dineroapostado;
        }

        public int tipo_Mercado { get; set; }
        public string TipoApuesta { get; set; }
        public double Cuota { get; set; }
        public double Dineroapostado { get; set; }

    }

}

