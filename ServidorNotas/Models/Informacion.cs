using Newtonsoft.Json;
using ServidorNotas.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorNotas.Models
{
    class Informacion
    {
        #region Datos
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Imagen { get; set; }
        #endregion
        #region Metodos Estaticos
        private static Informacion StringAObjeto(string datos)
        {
            Informacion inf = new Informacion();

            var datosSeparados = datos.Split(Separadores.Sep1);
            inf.Dni = datosSeparados[0];
            inf.Nombres = datosSeparados[1];
            inf.ApellidoPaterno = datosSeparados[2];
            inf.ApellidoMaterno = datosSeparados[3];
            inf.Telefono = datosSeparados[4];
            var anho_mes_dia = datosSeparados[5].Split('-');
            inf.FechaNacimiento = new DateTime(int.Parse(anho_mes_dia[0]), int.Parse(anho_mes_dia[1]), int.Parse(anho_mes_dia[2]));
            inf.Direccion = datosSeparados[6];
            inf.Correo = datosSeparados[7];
            inf.Imagen = datosSeparados[8];

            return inf;
        }
        public static Informacion GetInformacion(string dni)
        {
            if (dni == "")
                return null;
            var strInf = Servicios.ServicioUsuario.getInformacion(dni);
            if (strInf == "")
                return null;
            return StringAObjeto(strInf);
        }
        #endregion
        #region Override
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        #endregion

    }
}
