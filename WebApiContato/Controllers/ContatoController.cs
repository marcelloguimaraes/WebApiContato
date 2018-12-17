using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using WebApiContato.Models;

namespace WebApiContato.Controllers
{
    [RoutePrefix("api/contato")]
    public class ContatoController : ApiController
    {
        // GET api/contato
        [HttpGet]
        [ActionName("Get")]
        public IEnumerable<ContatoModel> Get(int size = 0, int page = 0)
        {
            if (size == 0)
                size = 10;

            var resultado = RepositorioContato.Contato.OrderBy(con => con.IdContato).Skip((page - 1) * size).Take(size);
            return resultado;
        }

        // GET api/contato/1
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ContatoModel contato = RepositorioContato.Contato.FirstOrDefault(con => con.IdContato == id);

            if (contato != null)
                return Ok(contato); //200
            else
                return Content(HttpStatusCode.NotFound, "Contato não encontrado"); //404
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]ContatoModel obj)
        {
            try
            {
                List<ContatoModel> contato = RepositorioContato.Contato;
                var id = contato.Max(con => con.IdContato);
                obj.IdContato = id + 1;

                RepositorioContato.Contato.Add(obj);
                return Content(HttpStatusCode.Created, new { id = obj.IdContato, retorno = "Contato criado" });
            }
            catch (Exception e)
            {
                return BadRequest("Ocorreu um erro genérico. " + e.Message);
            }
        }

        
        // PUT api/contato/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]ContatoModel obj)
        {
            try
            {
                ContatoModel contato = RepositorioContato.Contato.FirstOrDefault(con => con.IdContato == id);

                if (contato != null)
                {
                    contato.Nome = obj.Nome;
                    contato.Canal = obj.Canal;
                    contato.Valor = obj.Valor;
                    contato.Obs = obj.Obs;

                    return Content(HttpStatusCode.NoContent, "Contato alterado");
                }
                else
                    return Content(HttpStatusCode.NotFound, "Contato não encontrado");

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, new { retorno = "Erro genérico: " + e.Message}); //400
            }
        }

        // DELETE api/contato/5
        public IHttpActionResult Delete(int id)
        {
            ContatoModel contato = RepositorioContato.Contato.FirstOrDefault(con => con.IdContato == id);

            if (contato != null)
            {
                RepositorioContato.Contato.Remove(contato);
                return Content(HttpStatusCode.NoContent, "Contato excluído");
            }
            else
                return Content(HttpStatusCode.NotFound, "Contato não encontrado");
        }
    }
}
