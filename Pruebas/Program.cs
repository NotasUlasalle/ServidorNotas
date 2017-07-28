using Newtonsoft.Json;
using Pruebas.Models;
using Pruebas.ServicioCalificacion;
using Pruebas.ServicioUsuario;
using Pruebas.Util;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {

            
            /*Parallel.For(0, 100, (i) =>
              {

                  var client = new RestClient("http://localhost:64491");
                  var request = new RestRequest("saludo");

                  var stopwatch = new Stopwatch();
                  stopwatch.Start();
                  var res = client.Execute(request);
                  stopwatch.Stop();

                  Console.WriteLine($"{i}:\t{stopwatch.Elapsed.Milliseconds}\t{res.Content}");

              });*/
        }
    }
}
