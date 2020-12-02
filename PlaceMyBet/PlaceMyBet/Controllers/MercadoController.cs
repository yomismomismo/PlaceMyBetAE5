﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlaceMyBet.Models;

namespace PlaceMyBet.Controllers
{
    public class MercadoController : ApiController
    {
        // GET: api/Mercado
        public IEnumerable<MercadoDTO> Get()
        {
            var repo = new MercadoRepository();
            List<MercadoDTO> mercado = repo.RetrieveList();
            return mercado;
        }

        // GET: api/Mercado/5
        public Mercado Get(int id)
        {
            var repo = new MercadoRepository();
            Mercado mercado = repo.Retrieve(id);

            return mercado;
        }
                /*
        // GET: api/Apuesta/?tipoMercado=tipo&Email=email
        public IEnumerable<ApuestaMercado> GetApuestasMercado(double tipoMercado, string Email)
        {

            var repo = new MercadoRepository();
            List<ApuestaMercado> apuestasUser = repo.GetApuestasMercado(tipoMercado, Email);
            return apuestasUser;

        }
                */
        // POST: api/Mercado
        public void Post([FromBody]Mercado mercado)
        {
            var repo = new MercadoRepository();
            repo.save(mercado);
        }
        
        /*

        // PUT: api/Mercado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercado/5
        public void Delete(int id)
        {
        }*/
    }
}
