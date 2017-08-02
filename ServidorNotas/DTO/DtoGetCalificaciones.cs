using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNotas.DTO
{
    public class DtoGetCalificaciones
    {
        public string Dni { get; set; }
        public int Periodo { get; set; }
        public Guid Id { get; set; }
    }
}