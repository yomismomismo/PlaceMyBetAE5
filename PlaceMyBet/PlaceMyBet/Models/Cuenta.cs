using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Cuenta
    {



        public int CuentaID { get; set; }
        public string Nombre_Banco { get; set; }
        public int Tarjeta_Credito { get; set; }
        public int Saldo_Actual{ get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Cuenta(int cuentaID, string nombre_Banco, int tarjeta_Credito, int saldo_Actual, string usuarioId)
        {
            CuentaID = cuentaID;
            Nombre_Banco = nombre_Banco;
            Tarjeta_Credito = tarjeta_Credito;
            Saldo_Actual = saldo_Actual;
            UsuarioId = usuarioId;
        }
    }


}