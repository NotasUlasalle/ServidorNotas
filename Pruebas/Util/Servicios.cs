using Pruebas.ServicioCalificacion;
using Pruebas.ServicioUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas.Util
{
    class Servicios
    {
        private static calificacionClient servicioCalificacion = new calificacionClient();
        private static usuarioClient servicioUsuario = new usuarioClient();

        public static calificacionClient ServicioCalificacion { get => servicioCalificacion; set => servicioCalificacion = value; }
        public static usuarioClient ServicioUsuario { get => servicioUsuario; set => servicioUsuario = value; }
    }
}
