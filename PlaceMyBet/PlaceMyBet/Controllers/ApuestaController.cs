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
        public IEnumerable<ApuestaDTO> Get()
        {
            var repo = new ApuestaRepository();
            List<ApuestaDTO> apuesta = repo.RetrieveList();
            return apuesta;
        }

       //GET: api/Apuesta/5
        public Apuesta Get(int Id)
        {

            var repo = new ApuestaRepository();
            Apuesta a = repo.Retrieve(Id);
            return a;

        }

        
        // POST: api/Apuesta
        public void Post([FromBody]Apuesta apuesta)
        {
            var repoMercado = new MercadoRepository();
            var repo = new ApuestaRepository();

            repo.Save(apuesta);
            /*  var cuota = repo.RetrieveCuotas(apuesta);*/

                repoMercado.UpdateDinero(apuesta);
             /*  var dinero = repoMercado.RetrieveDinero(apuesta);

                repoMercado.Calculos(apuesta, dinero);
                repo.Save(apuesta, cuota);*/
        }
        /*
        // PUT: api/Apuesta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuesta/5
        public void Delete(int id)
        {
        }*/
    }
}
