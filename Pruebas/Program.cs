using Pruebas.ServicioCalificacion;
using Pruebas.ServicioUsuario;
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
            /*var servicio = new usuarioClient();
            var p = servicio.getPeriodos("72569020");
            //Console.WriteLine(p);
            var q = "█12▄2016-II█11▄2016-I█9▄2015-II█8▄2015-I█7▄2014-II█6▄2014-I█5▄";
            foreach(var x in p.Split('▄'))
            {
                foreach (var y in x.Split('█'))
                {
                    Console.Write($"{y}\t");
                }
                Console.WriteLine();
            }*/

            Parallel.For(0, 100, (i) =>
              {

                  var client = new RestClient("http://localhost:64491");
                  var request = new RestRequest("api/notas");

                  var stopwatch = new Stopwatch();
                  stopwatch.Start();
                  var res = client.Execute(request);
                  stopwatch.Stop();

                  Console.WriteLine($"{i}:\t{stopwatch.Elapsed.Seconds}\t{res.Content}");

              });
        }
    }
}
