using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlaceMyBet.Models;

namespace PlaceMyBet.Controllers
{
    public class EventoController : ApiController
    {
        // GET: api/Evento
        public IEnumerable<EventoDTO> Get()
        {
            var repo = new EventoRepository();
            List<EventoDTO> e = repo.RetrieveList();
            return e;
        }

        /*** Ejercicio 1 ***/
        // GET: api/Eventos/?nombre=nombre
        public IEnumerable<Mercado> Get(string nombre)
        {

            var repo = new EventoRepository();
            List<Mercado> e = repo.apuestaEvento(nombre);
            return e;

        }

        /*** Fin Ejercicio 1 ***/
        /*
        // GET: api/Evento/?idEvento=id&tipoMercado=tipo
        public Mercado GetMercado(int idEvento, double tipoMercado)
        {
            var repoMercado = new MercadoRepository();
            Mercado e = repoMercado.getMercado(idEvento, tipoMercado);
            return e;

        }*/

        // POST: api/Evento
        public void Post([FromBody] Evento evento)
        {
            Debug.WriteLine("evento val" + evento);
            var repo = new EventoRepository();
            repo.Save(evento);
        }
        
    // PUT: api/Evento/5
    public void Put(int id, [FromBody]Evento evento)
        {
            var repo = new EventoRepository();
            repo.updateDinero(id, evento);

        }
        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
            var repo = new EventoRepository();
            repo.DeleteEvento(id);
        }
    }
}
