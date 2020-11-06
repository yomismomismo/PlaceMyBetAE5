using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Mercado
    {


        public int MercadoID { get; set; }
        public double OverUnder { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }
        public double DineroOver { get; set; }
        public double DineroUnder { get; set; }
        public int EventoID { get; set; }
        public Evento Evento { get; set; }



        public List<Apuesta> Apuestas { get; set; }

        public Mercado(int mercadoID, double overUnder, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder, int eventoID)
        {
            MercadoID = mercadoID;
            OverUnder = overUnder;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            DineroOver = dineroOver;
            DineroUnder = dineroUnder;
            EventoID = eventoID;
        }
    }

    public class MercadoDTO
    {
        public MercadoDTO(double overUnder, double cuotaOver, double cuotaUnder)
        {
            OverUnder = overUnder;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
        }

        public double OverUnder { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }

    }

    public class MercadoDinero
    {
        public MercadoDinero(int mercadoID, double dineroOver, double dineroUnder)
        {
            MercadoID = mercadoID;
            DineroOver = dineroOver;
            DineroUnder = dineroUnder;
        }

        public int MercadoID { get; set; }
        public double DineroOver { get; set; }
        public double DineroUnder { get; set; }}

    }