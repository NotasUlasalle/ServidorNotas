using ServidorNotas.DTO;
using ServidorNotas.Sesion;
using ServidorNotas.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ServidorNotas.Controllers
{
    public class SesionController : ApiController
    {
        [HttpPost]
        [Route("sesion/iniciarsesion")]
        public async Task<IHttpActionResult> IniciarSesion([FromBody] DtoInicioSesion dtoInicioSesion)
        {

            return await Task.Run<IHttpActionResult>(() =>
            {
                var res = Servicios.ServicioUsuario.sesionValida(dtoInicioSesion.Dni, dtoInicioSesion.Contrasena);
                if (res)
                {
                    Guid id = Sesiones.Instancia.CrearSesion(dtoInicioSesion.Dni);
                    return Ok(new { Token = id });
                }
                else
                    return Ok(new { Token = Guid.Empty });
            });
        }

        [HttpGet]
        [Route("sesion/sesiones")]
        public async Task<IHttpActionResult> GetSesiones()
        {
            return await Task.Run<IHttpActionResult>(() => {
                return Ok(Sesiones.Instancia.GetSesiones());
            });
        }
    }
}