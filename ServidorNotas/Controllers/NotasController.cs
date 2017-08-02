using ServidorNotas.DTO;
using ServidorNotas.Models;
using ServidorNotas.Sesion;
using ServidorNotas.Util;
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
       
        [HttpPost]
        [Route("notas/calificaciones")]
        public async Task<IHttpActionResult> GetCalificaciones([FromBody] DtoGetCalificaciones dto)
        {
            return await Task.Run(() =>
            {
                var valido = Sesiones.Instancia.RevisarSesion(dto.Id);
                dynamic res = null;
                if (valido)
                    res = Calificaciones.GetCalificaciones(dto.Dni, dto.Periodo);
                return Ok(new { Respuesta = res });
            });
        }


    }
}