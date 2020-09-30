using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Mercado
    {

        public Mercado(int mercadoID, double overUnder, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder, int evento_ID)
        {
            MercadoID = mercadoID;
            OverUnder = overUnder;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            DineroOver = dineroOver;
            DineroUnder = dineroUnder;
            Evento_ID = evento_ID;
        }

        public int MercadoID { get; set; }
        public double OverUnder { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }
        public double DineroOver { get; set; }
        public double DineroUnder { get; set; }
        public int Evento_ID { get; set; }
    }

}