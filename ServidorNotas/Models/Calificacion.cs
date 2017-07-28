using Newtonsoft.Json;
using ServidorNotas.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorNotas.Models
{
    class Calificaciones
    {
        #region Datos
        public int Periodo { get; set; }
        public int NumeroCalificaciones { get; set; }
        public Calificacion[] ListaCalificaciones { get; set; }
        #endregion
        #region Metodos Estaticos
        public static Calificaciones StringAObjeto(string datos)
        {
            Calificaciones calificaciones = new Calificaciones();
            var separacion1 = datos.Split(Separadores.Sep3);
            calificaciones.Periodo = int.Parse(separacion1[0]);
            calificaciones.NumeroCalificaciones = int.Parse(separacion1[1]);
            calificaciones.ListaCalificaciones = new Calificacion[separacion1.Length - 3];
            for (int i = 2; i < separacion1.Length - 1; i++)
            {
                int index = i - 2;
                calificaciones.ListaCalificaciones[index] = new Calificacion();
                var separacion2 = separacion1[i].Split(Separadores.Sep1);
                calificaciones.ListaCalificaciones[index].Nombre = separacion2[0];
                calificaciones.ListaCalificaciones[index].Promedio = double.Parse(separacion2[1], CultureInfo.InvariantCulture);
                var separacion3 = separacion2[2].Split(Separadores.Sep2);
                calificaciones.ListaCalificaciones[index].Parcial = double.Parse(separacion3[0].Split(Separadores.Sep4)[1], CultureInfo.InvariantCulture);
                calificaciones.ListaCalificaciones[index].Final = double.Parse(separacion3[1].Split(Separadores.Sep4)[1], CultureInfo.InvariantCulture);
                calificaciones.ListaCalificaciones[index].Permanente1 = double.Parse(separacion3[2].Split(Separadores.Sep4)[1], CultureInfo.InvariantCulture);
                calificaciones.ListaCalificaciones[index].Permanente2 = double.Parse(separacion3[3].Split(Separadores.Sep4)[1], CultureInfo.InvariantCulture);
                calificaciones.ListaCalificaciones[index].Evidencia1 = double.Parse(separacion3[4].Split(Separadores.Sep4)[1], CultureInfo.InvariantCulture);
                calificaciones.ListaCalificaciones[index].Evidencia2 = double.Parse(separacion3[5].Split(Separadores.Sep4)[1], CultureInfo.InvariantCulture);
                calificaciones.ListaCalificaciones[index].Evidencia3 = double.Parse(separacion3[6].Split(Separadores.Sep4)[1], CultureInfo.InvariantCulture);
                calificaciones.ListaCalificaciones[index].Evidencia4 = double.Parse(separacion3[7].Split(Separadores.Sep4)[1], CultureInfo.InvariantCulture);
            }
            return calificaciones;
        }
        public static Calificaciones GetCalificaciones(string dni, int periodo)
        {
            var strCalificacion = Servicios.ServicioCalificacion.getCalificaciones(dni, periodo);
            return StringAObjeto(strCalificacion);
        }
        #endregion
        #region Override
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        #endregion
    }
    class Calificacion
    {
        public string Nombre { get; set; }
        public double Promedio { get; set; }
        public double Parcial { get; set; }
        public double Final { get; set; }
        public double Permanente1 { get; set; }
        public double Permanente2 { get; set; }
        public double Evidencia1 { get; set; }
        public double Evidencia2 { get; set; }
        public double Evidencia3 { get; set; }
        public double Evidencia4 { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
