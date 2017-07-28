using ServidorNotas.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ServidorNotas.Controllers
{
    public class NotasController : ApiController
    {
        [HttpGet]
        [Route("calificaciones/{dni}/{periodo}")]
        public async Task<IHttpActionResult> Get(string dni, string periodo)
        {
            return await Task.Run(() => 
            {
                var res = Calificaciones.GetCalificaciones(dni,int.Parse(periodo));
                return Ok(res);
            });       
        }
    }
}