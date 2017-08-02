using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNotas.Sesion
{
    public class Sesion
    {
        public Guid ID { get; set; }
        public string Dni { get; set; }
        public DateTime Fecha { get; set; }
    }
}