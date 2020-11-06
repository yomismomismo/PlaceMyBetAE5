using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Usuario
    {

        [System.ComponentModel.DataAnnotations.Key]
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public List<Apuesta> Apuestas { get; set; }

        public Cuenta Cuenta { get; set; }

        public Usuario()
        {

        }

        public Usuario(string email, string nombre, string apellido, int edad)
        {
            Email = email;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
        }
    }



}