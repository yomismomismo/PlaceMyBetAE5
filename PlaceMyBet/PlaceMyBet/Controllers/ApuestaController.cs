using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlaceMyBet.Models;

namespace PlaceMyBet.Controllers
{
    public class ApuestaController : ApiController
    {
        // GET: api/Apuesta
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Apuesta/5
        public ApuestaDTO Get(int id)
        {

            var repo = new ApuestaRepository();
            ApuestaDTO a = repo.Retrieve();
            return a;

        }


        // POST: api/Apuesta
        public void Post([FromBody]ApuestaDTO apuesta)
        {
            var repoMercado = new MercadoRepository();
            var repo = new ApuestaRepository();

           var cuota = repo.RetrieveCuotas(apuesta);

            repoMercado.UpdateDinero(apuesta);
           var dinero = repoMercado.RetrieveDinero();

            repoMercado.Calculos(apuesta, dinero);
            repo.Save(apuesta, cuota);
        }

        // PUT: api/Apuesta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuesta/5
        public void Delete(int id)
        {
        }
    }
}
