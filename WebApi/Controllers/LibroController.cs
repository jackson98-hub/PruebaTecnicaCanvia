using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class LibroController : ApiController
    {
        // GET api/<controller>
        public List<Libro> Get()
        {
            return LibroData.Listar();
        }

        // GET api/<controller>/5
        public Libro Get(int id)
        {
            return LibroData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Libro oLibro)
        {
            return LibroData.Registrar(oLibro);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Libro oLibro)
        {
            return LibroData.Modificar(oLibro);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return LibroData.Eliminar(id);
        }
    }
}