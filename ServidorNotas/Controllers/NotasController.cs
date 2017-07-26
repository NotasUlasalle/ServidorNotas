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
        public string Get()
        {
            return "Hola";
        }
    }
}